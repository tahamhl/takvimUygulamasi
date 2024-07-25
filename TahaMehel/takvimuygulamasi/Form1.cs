using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace gorseltakvim
{
    public partial class Form1 : Form
    {
        private DateTime _currentWeekStart;
        private Dictionary<DateTime, string[]> Not_Tut = new Dictionary<DateTime, string[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Formun kullanýcý ekranýna göre baþlangýç pozisyonu ayarlanýr
            var screenSize = Screen.PrimaryScreen.Bounds;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = screenSize.Width / 2;
            this.Height = screenSize.Height;
            this.Left = screenSize.Width / 2;
            this.Top = 0;

            // Haftanýn baþlangýç tarihi DataGridView ile dolduruluyor
            _currentWeekStart = BaslaHafta(DateTime.Now, DayOfWeek.Monday);
            dataGridView1.DataSource = TakvimYap(_currentWeekStart);
        }

        // Form'un baþlýk çubuðunu sürüklemeye izin vermek için WndProc metodunun override edilir
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HT_CAPTION = 0x2;

            if (m.Msg == WM_NCLBUTTONDOWN && (int)m.WParam == HT_CAPTION)
            {
                return;
            }

            base.WndProc(ref m);
        }

        // Takvim DataGridView ile doldurulur ve tarih bilgileri eklenir
        private void TakvimiYarat()
        {
            DataTable table = TakvimYap(_currentWeekStart);
            dataGridView1.DataSource = table;

            // Notlarýn takvimdeki yerlerine yerleþtirilmesi
            for (int i = 1; i < table.Columns.Count; i++)
            {
                DateTime date = _currentWeekStart.AddDays(i - 1);
                string[] dailyNotes;
                if (Not_Tut.TryGetValue(date, out dailyNotes))
                {
                    for (int j = 0; j < dailyNotes.Length; j++)
                    {
                        table.Rows[j][i] = dailyNotes[j];
                    }
                }
            }
        }

        // Haftalýk takvim oluþturulur
        private DataTable TakvimYap(DateTime weekStart)
        {
            CultureInfo ci = new CultureInfo("tr-TR");
            DataTable table = new DataTable();

            table.Columns.Add("Saat", typeof(string));

            // Tarih ile birlikte denk gelen günler eklenir
            for (int i = 0; i < 7; i++)
            {
                DateTime date = weekStart.AddDays(i);
                string dayName = date.ToString("dddd", ci);
                string dayDate = date.ToString("dd/MM/yyyy", ci);
                string columnHeader = $"{dayName}\n({dayDate})";
                table.Columns.Add(columnHeader, typeof(string));
            }

            // Her gün için saat satýrlarý eklenir
            for (int hour = 0; hour < 24; hour++)
            {
                DataRow row = table.NewRow();
                row["Saat"] = hour.ToString("00") + ":00";
                table.Rows.Add(row);
            }

            return table;
        }

        // Belirli bir günün baþlangýcýný bulan metod
        private DateTime BaslaHafta(DateTime dt, DayOfWeek BaslaHafta)
        {
            int diff = (7 + (dt.DayOfWeek - BaslaHafta)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        // Ýleri butonuna týklandýðýnda bir hafta ileriye taþýyacak fonksiyon
        private void sonrakibuton_Click(object sender, EventArgs e)
        {
            KaydetNot();
            _currentWeekStart = _currentWeekStart.AddDays(7);
            dataGridView1.DataSource = TakvimYap(_currentWeekStart);
            TakvimiYarat();
        }

        // Geri butonuna týklandýðýnda bir hafta ileriye taþýyacak fonksiyon
        private void oncekibuton_Click(object sender, EventArgs e)
        {
            KaydetNot();
            _currentWeekStart = _currentWeekStart.AddDays(-7);
            dataGridView1.DataSource = TakvimYap(_currentWeekStart);
            TakvimiYarat();
        }

        // Silme butonuna týklandýðýnda seçili hücrenin içindeki mesajý silen fonksiyon
        private void silbuton_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int selectedColumnIndex = dataGridView1.CurrentCell.ColumnIndex;

            DateTime selectedDate = _currentWeekStart.AddDays(selectedColumnIndex - 1);
            int selectedHour = selectedRowIndex;

            if (Not_Tut.ContainsKey(selectedDate))
            {
                Not_Tut[selectedDate][selectedHour] = string.Empty;
                dataGridView1.CurrentCell.Value = string.Empty;
            }
        }

        // Kullanýcýnýn girdiði notlarý kaydeden ilgili fonksiyon
        private void KaydetNot()
        {
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                DateTime date = _currentWeekStart.AddDays(i - 1);
                string[] dailyNotes = new string[24];
                for (int j = 0; j < 24; j++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Value != null)
                    {
                        dailyNotes[j] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                    }
                    else
                    {
                        dailyNotes[j] = string.Empty;
                    }
                }
                if (Not_Tut.ContainsKey(date))
                {
                    Not_Tut[date] = dailyNotes;
                }
                else
                {
                    Not_Tut.Add(date, dailyNotes);
                }
            }
        }

        // Hücreleri seçen fonksiyon
        private void NotSatiriniSec(int hour, DateTime date)
        {
            int columnIndex = ((int)(date - _currentWeekStart).TotalDays) + 1;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = dataGridView1.Rows[hour].Cells[columnIndex];
            dataGridView1.Rows[hour].Cells[columnIndex].Selected = true;
        }

        // Kullanýcýnýn arama yapacaðý yerin fonksiyonu
        private void Bul_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var entry in Not_Tut)
            {
                string[] dailyNotes = entry.Value;
                for (int hour = 0; hour < dailyNotes.Length; hour++)
                {
                    if (!string.IsNullOrEmpty(dailyNotes[hour]) && dailyNotes[hour].ToLower().Contains(Bul.Text))
                    {
                        _currentWeekStart = BaslaHafta(entry.Key, DayOfWeek.Monday);
                        TakvimiYarat();
                        NotSatiriniSec(hour, entry.Key);
                        return;
                    }
                }
            }
        }

    }
}

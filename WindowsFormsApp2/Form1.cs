using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=SA107P8\SQLEXPRESS;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dtUygulama.mdf;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            göster();

        }
        private void göster()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tblTamirOlacaklar", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblTamirOlacaklar");
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut1 = new SqlCommand("insert into tblTamirOlacaklar (MusteriAdı,Miktar,Cinsi,MalTanımı,Islem,Telefon,Tutar,Tarih,Ödeme) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@Tarih,@ödeme)", baglantı);
            if (radioButton1.Checked)
            {
                komut1.Parameters.AddWithValue("@ödeme",radioButton1.Text);

            }
            else if (radioButton2.Checked)
            {
                komut1.Parameters.AddWithValue("@ödeme",radioButton2.Text);

            }
            else
            {
                MessageBox.Show("Tutarın alınıp alınmadıgını seçiniz");
                baglantı.Close();

            }


            while (radioButton1.Checked || radioButton2.Checked)
            {

            

            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut1.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut1.Parameters.AddWithValue("@p4", textBox2.Text);
            komut1.Parameters.AddWithValue("@p5", textBox3.Text);
            komut1.Parameters.AddWithValue("@p6", textBox5.Text);
            komut1.Parameters.AddWithValue("@p7", textBox4.Text);
            komut1.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        
           

            komut1.ExecuteNonQuery();

            baglantı.Close();
            MessageBox.Show("tamir eklendi");
            göster();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                break;
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("delete from tblTamirOlacaklar where MusteriAdı=@p1", baglantı);
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.ExecuteNonQuery();
            baglantı.Close();
            göster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            radioButton1.Checked= false;
            radioButton2.Checked= false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()=="Ödendi")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else if(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() == "Ödenmedi")
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked= true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("hata");
            }
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("insert into tblTamirOlanlar(MuşteriAdı, Miktar, Cinsi, MalTanımı, Islem, Telefon, Tutar,VerilisTarihi,AlanınTelefon) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7,@p8,@p9)", baglantı);
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut1.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut1.Parameters.AddWithValue("@p4", textBox2.Text);
            komut1.Parameters.AddWithValue("@p5", textBox3.Text);
            komut1.Parameters.AddWithValue("@p6", textBox5.Text);
            komut1.Parameters.AddWithValue("@p7", textBox4.Text);
            komut1.Parameters.AddWithValue("@p8", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            komut1.Parameters.AddWithValue("@p9", textBox6.Text);

            komut1.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("delete from tblTamirOlacaklar where MusteriAdı=@p10", baglantı);
            komut2.Parameters.AddWithValue("@p10", textBox1.Text);
            komut2.ExecuteNonQuery();
            baglantı.Close();
            göster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            TamirOlanlar fs = new TamirOlanlar();
            fs.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            e.Graphics.DrawLine(myPen, 120, 120, 750, 120);
            e.Graphics.DrawLine(myPen, 120, 180, 750, 180);
            e.Graphics.DrawString("TAMİR FİŞİ", myFont, sbrush, 200, 120);

            e.Graphics.DrawLine(myPen, 120, 320, 750, 320);

            myFont = new Font("Calibri", 12, FontStyle.Bold);
            e.Graphics.DrawString("Adet", myFont, sbrush, 140, 328);
            e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 240, 328);
            e.Graphics.DrawString("Birim Fiyatı", myFont, sbrush, 440, 328);
            e.Graphics.DrawString("Fiyat", myFont, sbrush, 640, 328);

            e.Graphics.DrawLine(myPen, 120, 348, 750, 348);

            int y = 360;

            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Far;





            e.Graphics.DrawString(textBox1.Text, myFont, sbrush, 160, y, myStringFormat);
            e.Graphics.DrawString(textBox2.Text, myFont, sbrush, 220, y);

            e.Graphics.DrawString(textBox3.Text, myFont, sbrush, 530, y, myStringFormat);
            e.Graphics.DrawString(textBox5.Text, myFont, sbrush, 700, y, myStringFormat);




            e.Graphics.DrawLine(myPen, 120, y, 750, y);
           // e.Graphics.DrawString(gTotal.ToString("c"), myFont, sbrush, 700, y + 10, myStringFormat);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
        }
    
    }
}

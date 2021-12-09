using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoteriaMexicana
{
    public partial class Form1 : Form
    {
        Stack<int> CARTAS = new Stack<int>();
        Random random = new Random();
        const int CANTIDAD_CARTAS = 54;
        private PictureBox[] cartas;
        private PictureBox[] tabla;
        public Form1()
        {
            InitializeComponent();
            cartas = new PictureBox[54];
            tabla = new PictureBox[25];
            inicalizarTabla();
        }

        private void inicalizarTabla()
        {
            int r=0, c = 0;

            int[] cartas = new int[34];
           

            for (int i = 0; i <cartas.Length; i++)
            {
                cartas[i]= i +1;
            }

            //recorrer el arreaglo para SWAP
            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }

            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(100+(c*90), 25+(r*125));
                tabla[i].Name = "picTabla"+i;
                tabla[i].Size = new System.Drawing.Size(85, 120);
                tabla[i].TabIndex = 0+i;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"cartas\"+(cartas[i])+".jpg");
                this.Controls.Add(tabla[i]);
                c++;
                if (c==5)
                {
                    r++;
                    c = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 220);
            this.listView1.LargeImageList = this.imageList1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (54 - cartas.Count()).ToString();
            bool bandera = false;
            if (cartas.Count()==54)
            {
                bandera = true;
                MessageBox.Show("son todas las cartas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

             while(!bandera)
            {
                int num = random.Next(1, 54);
                if (CARTAS.Contains(num))
                {
                    pbcartas.Image = Image.FromFile(@"Bibliotecas\Documentos"+num+".jpg");
                    pbcartas.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.imageList1.Images.Add(Image.FromFile(@"Bibliotecas\Documentos" + num + ".jpg"));
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                    bandera = true;
                    j++;



                }
            }
        }
    }
}

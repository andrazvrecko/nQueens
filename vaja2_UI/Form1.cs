using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace vaja2_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Serializable]
        public struct algM
        {
            public int ocena;
            public int[,] poteza;
            public algM(int x, int[,]y)
            {
                ocena = x;
                poteza = y;
                
            }
        }

        static public T DeepCopy<T>(T obj)
        {
            BinaryFormatter s = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                s.Serialize(ms, obj);
                ms.Position = 0;
                T t = (T)s.Deserialize(ms);

                return t;
            }
        }

        public int[,] gamePolje = new int[3, 3] {{0,0,0}, { 0, 0, 0 }, { 0, 0, 0}};
        public int turn = 0; //1 - MAX, 2 - MIN
        public int diff;

        

        public void printPolje(int[,] polje)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(polje[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public int hevOcena(int[,] polje)
        {
            int ocena = 0;


                if ((polje[0, 0] == 1) && (polje[0, 1] == 1) && (polje[0, 2] == 1))
                    return 1000;
                if ((polje[1, 0] == 1) && (polje[1, 1] == 1) && (polje[1, 2] == 1))
                    return 1000;
                if ((polje[2, 0] == 1) && (polje[2, 1] == 1) && (polje[2, 2] == 1))
                    return 1000;

                if ((polje[0, 0] == 1) && (polje[1, 0] == 1) && (polje[2, 0] == 1))
                    return 1000;
                if ((polje[0, 1] == 1) && (polje[1, 1] == 1) && (polje[2, 1] == 1))
                    return 1000;
                if ((polje[0, 2] == 1) && (polje[1, 2] == 1) && (polje[2, 2] == 1))
                    return 1000;

                if ((polje[0, 0] == 1) && (polje[1, 1] == 1) && (polje[2, 2] == 1))
                    return 1000;
                if ((polje[0, 2] == 1) && (polje[1, 1] == 1) && (polje[2, 0] == 1))
                    return 1000;
                //winning pos MIN
                if ((polje[0, 0] == 2) && (polje[0, 1] == 2) && (polje[0, 2] == 2))
                    return -1000;
                if ((polje[1, 0] == 2) && (polje[1, 1] == 2) && (polje[1, 2] == 2))
                    return -1000;
                if ((polje[2, 0] == 2) && (polje[2, 1] == 2) && (polje[2, 2] == 2))
                    return -1000;

                if ((polje[0, 0] == 2) && (polje[1, 0] == 2) && (polje[2, 0] == 2))
                    return -1000;
                if ((polje[0, 1] == 2) && (polje[1, 1] == 2) && (polje[2, 1] == 2))
                    return -1000;
                if ((polje[0, 2] == 2) && (polje[1, 2] == 2) && (polje[2, 2] == 2))
                   return -1000;

                if ((polje[0, 0] == 2) && (polje[1, 1] == 2) && (polje[2, 2] == 2))
                    return -1000;
                if ((polje[0, 2] == 2) && (polje[1, 1] == 2) && (polje[2, 0] == 2))
                    return -1000;


                //MAX
                if ((polje[0, 0] == 0 || polje[0, 0] == 1) && (polje[0, 1] == 0 || polje[0, 1] == 1) && (polje[0, 2] == 0 || polje[0, 2] == 1))
                    ocena++;
                if ((polje[1, 0] == 0 || polje[1, 0] == 1) && (polje[1, 1] == 0 || polje[1, 1] == 1) && (polje[1, 2] == 0 || polje[1, 2] == 1))
                    ocena++;
                if ((polje[2, 0] == 0 || polje[2, 0] == 1) && (polje[2, 1] == 0 || polje[2, 1] == 1) && (polje[2, 2] == 0 || polje[2, 2] == 1))
                    ocena++;

                if ((polje[0, 0] == 0 || polje[0, 0] == 1) && (polje[1, 0] == 0 || polje[1, 0] == 1) && (polje[2, 0] == 0 || polje[2, 0] == 1))
                    ocena++;
                if ((polje[0, 1] == 0 || polje[0, 1] == 1) && (polje[1, 1] == 0 || polje[1, 1] == 1) && (polje[2, 1] == 0 || polje[2, 1] == 1))
                    ocena++;
                if ((polje[0, 2] == 0 || polje[0, 2] == 1) && (polje[1, 2] == 0 || polje[1, 2] == 1) && (polje[2, 2] == 0 || polje[2, 2] == 1))
                    ocena++;

                if ((polje[0, 0] == 0 || polje[0, 0] == 1) && (polje[1, 1] == 0 || polje[1, 1] == 1) && (polje[2, 2] == 0 || polje[2, 2] == 1))
                    ocena++;
                if ((polje[0, 2] == 0 || polje[0, 2] == 1) && (polje[1, 1] == 0 || polje[1, 1] == 1) && (polje[2, 0] == 0 || polje[2, 0] == 1))
                    ocena++;
                //MIN
                if ((polje[0, 0] == 0 || polje[0, 0] == 2) && (polje[0, 1] == 0 || polje[0, 1] == 2) && (polje[0, 2] == 0 || polje[0, 2] == 2))
                    ocena--;
                if ((polje[1, 0] == 0 || polje[1, 0] == 2) && (polje[1, 1] == 0 || polje[1, 1] == 2) && (polje[1, 2] == 0 || polje[1, 2] == 2))
                    ocena--;
                if ((polje[2, 0] == 0 || polje[2, 0] == 2) && (polje[2, 1] == 0 || polje[2, 1] == 2) && (polje[2, 2] == 0 || polje[2, 2] == 2))
                    ocena--;

                if ((polje[0, 0] == 0 || polje[0, 0] == 2) && (polje[1, 0] == 0 || polje[1, 0] == 2) && (polje[2, 0] == 0 || polje[2, 0] == 2))
                    ocena--;
                if ((polje[0, 1] == 0 || polje[0, 1] == 2) && (polje[1, 1] == 0 || polje[1, 1] == 2) && (polje[2, 1] == 0 || polje[2, 1] == 2))
                    ocena--;
                if ((polje[0, 2] == 0 || polje[0, 2] == 2) && (polje[1, 2] == 0 || polje[1, 2] == 2) && (polje[2, 2] == 0 || polje[2, 2] == 2))
                    ocena--;

                if ((polje[0, 0] == 0 || polje[0, 0] == 2) && (polje[1, 1] == 0 || polje[1, 1] == 2) && (polje[2, 2] == 0 || polje[2, 2] == 2))
                    ocena--;
                if ((polje[0, 2] == 0 || polje[0, 2] == 2) && (polje[1, 1] == 0 || polje[1, 1] == 2) && (polje[2, 0] == 0 || polje[2, 0] == 2))
                    ocena--;
                return ocena;
            
            //winning pos MAX
            
        }

        public bool gameOver(int[,] polje)//preveri ce je list
        {
            if (hevOcena(polje) == 1000 || hevOcena(polje) == -1000)
                return true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (polje[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public algM minmaks(int[,] polje, int poteza, int d)
        {
            algM bestcase = new algM();
            if (gameOver(polje) || d == 0)
            {
                algM temp = new algM(hevOcena(polje), null);
                return temp;
            }
                
            int ocena;
            if (poteza == 1) //MAX
            {
                ocena = -1000;
            }
            else
            {//MIN
                ocena = 1000;
            }
            algM retVal = new algM();

            //bestcase.poteza = DeepCopy(polje);
            //bestcase.poteza = polje;

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(polje[i,j] == 0)
                    {
                        bestcase.poteza = DeepCopy(polje); //gre do prve 0, to 0 nastavi na stevilko igralca
                        bestcase.poteza[i, j] = DeepCopy(poteza);

                        if (poteza == 1)
                            poteza = 2;
                        else
                            poteza = 1;

                        algM temp2 = minmaks(bestcase.poteza, poteza, d - 1);

                        if (poteza == 1)
                            poteza = 2;
                        else
                            poteza = 1;

                        if ((poteza == 1 && temp2.ocena > ocena) || (poteza == 2 && temp2.ocena < ocena)) {
                            ocena = temp2.ocena;
                            retVal.ocena = temp2.ocena;
                            retVal.poteza = DeepCopy(bestcase.poteza);
                        }
                    }
                }
            }

            //retVal.ocena = ocena;
            return retVal;
        }

        public void colorBoard()
        {
            if (gamePolje[0, 0] == 1)
                button1.BackColor = Color.Blue;
            if (gamePolje[1, 0] == 1)
                button4.BackColor = Color.Blue;
            if (gamePolje[2, 0] == 1)
                button7.BackColor = Color.Blue;
            if (gamePolje[0, 1] == 1)
                button2.BackColor = Color.Blue;
            if (gamePolje[0, 2] == 1)
                button3.BackColor = Color.Blue;
            if (gamePolje[1, 1] == 1)
                button5.BackColor = Color.Blue;
            if (gamePolje[1, 2] == 1)
                button6.BackColor = Color.Blue;
            if (gamePolje[2, 1] == 1)
                button8.BackColor = Color.Blue;
            if (gamePolje[2, 2] == 1)
                button9.BackColor = Color.Blue;

            if (gamePolje[0, 0] == 2)
                button1.BackColor = Color.Red;
            if (gamePolje[1, 0] == 2)
                button4.BackColor = Color.Red;
            if (gamePolje[2, 0] == 2)
                button7.BackColor = Color.Red;
            if (gamePolje[0, 1] == 2)
                button2.BackColor = Color.Red;
            if (gamePolje[0, 2] == 2)
                button3.BackColor = Color.Red;
            if (gamePolje[1, 1] == 2)
                button5.BackColor = Color.Red;
            if (gamePolje[1, 2] == 2)
                button6.BackColor = Color.Red;
            if (gamePolje[2, 1] == 2)
                button8.BackColor = Color.Red;
            if (gamePolje[2, 2] == 2)
                button9.BackColor = Color.Red;

            if (gamePolje[0, 0] == 0)
                button1.BackColor = Color.LightGray;
            if (gamePolje[1, 0] == 0)
                button4.BackColor = Color.LightGray;
            if (gamePolje[2, 0] == 0)
                button7.BackColor = Color.LightGray;
            if (gamePolje[0, 1] == 0)
                button2.BackColor = Color.LightGray;
            if (gamePolje[0, 2] == 0)
                button3.BackColor = Color.LightGray;
            if (gamePolje[1, 1] == 0)
                button5.BackColor = Color.LightGray;
            if (gamePolje[1, 2] == 0)
                button6.BackColor = Color.LightGray;
            if (gamePolje[2, 1] == 0)
                button8.BackColor = Color.LightGray;
            if (gamePolje[2, 2] == 0)
                button9.BackColor = Color.LightGray;

        }
        public void gameStart()
        {
            turn = 1;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    gamePolje[i, j] = 0;
                }
            }
            colorBoard();
            diff = int.Parse(comboBox1.SelectedItem.ToString());
            Console.WriteLine(diff);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(turn == 1)
            {
                gamePolje[0, 0] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[0, 1] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //int[,] polje = new int[3, 3] { { 0, 0, 2 }, { 0, 1, 1}, { 0, 0, 0 } };
            //Console.WriteLine(hevOcena(polje));
            //algM a = minmaks(polje, 2, 2);
            //printPolje(a.poteza);
            gameStart();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[0, 2] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[1, 0] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[1, 1] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[1, 2] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[2, 0] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[2, 1] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                gamePolje[2, 2] = 1;
                colorBoard();
                if (!gameOver(gamePolje))
                {
                    algM temp = minmaks(gamePolje, 2, diff);
                    gamePolje = DeepCopy(temp.poteza);
                }
                else
                {
                    turn = 0;
                }
                colorBoard();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

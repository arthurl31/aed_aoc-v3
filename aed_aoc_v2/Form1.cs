using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace aed_aoc_v2
{
    public partial class Form1 : Form
    {
        #region formulas
        /*      FORMULAS BASICAS AOC
         * tamanhoMR / tamanhoBloco --> cria memoriaRam
         * linhasCache / n --> cria a quantdade de conjuntos
         * numeroDigitado % quantidadeConjuntos ---> descobre qual conjunto o numero digitado vai cair
         */
        #endregion

        #region variaveis e vetores
        Random r = new Random();
        public int tamanhoBloco = 0;
        public int t1 = 0;
        public Int32 menorContador;
        public int tamanhoMR = 0;
        DateTime menor = new DateTime();
        public int[] blocos;
        public int[] ContAcesso;
        public string[] HoraCarregada;
        public string[] DataAcesso;
        public int j = 0;
        public int anterior = 0;
        public int linhasCache;
        public int n;
        public int eficiencia = 0;
        public int hits = 0;
        #endregion

        #region Forms
        TelaCarregamento t = new TelaCarregamento();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            t.ShowDialog();

            this.hit_miss.Hide();
            this.Cache.ForeColor = Color.Black;
            this.Ram.ForeColor = Color.Black;
        }
        #endregion

        #region Botões Forms

        private void BotaoAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Convert.ToInt32(Interaction.InputBox("Digite o bloco a ser acessado", "Acessar Bloco", "", -1, -1));
                if (this.comboBox1.SelectedIndex == 0)
                {
                    menor = DateTime.Now;

                    StringBuilder str = new StringBuilder();
                    str.Append($" - {input}{labelSequencia.Text}");
                    labelSequencia.Text = str.ToString();

                    FIFO(input);
                }
                else if (this.comboBox1.SelectedIndex == 1)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append($" - {input}{labelSequencia.Text}");
                    labelSequencia.Text = str.ToString();

                    menor = DateTime.Now;
                    LRU(input);
                }
                else if (this.comboBox1.SelectedIndex == 2)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append($" - {input}{labelSequencia.Text}");
                    labelSequencia.Text = str.ToString();

                    menorContador = Int32.MaxValue;
                    LFU(input);
                }
            }
            catch (Exception)
            {

            }

        } //botao acessar - pega o dado digitado pro usuario e acessa o bloco na ram e passa para cache

        private void BotaoGO_Click(object sender, EventArgs e)
        {
            if (!ValidaCampos())
            {
                MessageBox.Show("Preencha Todos os Campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                tamanhoMR = Convert.ToInt32(this.textBox1.Text);
                tamanhoBloco = Convert.ToInt32(this.textBox2.Text);
                n = Convert.ToInt32(this.textBox3.Text);
                linhasCache = Convert.ToInt32(this.textBox4.Text);

                if (!(tamanhoMR < tamanhoBloco) && tamanhoMR % tamanhoBloco != 0 && linhasCache % n != 0) //valida se bloco é maior que a memoria e se valores são multiplos do tamanho da MR
                {
                    if (tamanhoMR % tamanhoBloco != 0) //valida multiplo ram e bloco
                        MessageBox.Show("Tamanho da memoria RAM deve ser MULTIPLO do tamanho do Bloco", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    else
                        MessageBox.Show("Bloco NÃO pode ser maior que a Memoria.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (linhasCache % n != 0) //valida multiplo cache e N
                        MessageBox.Show("Numero de linhas da Cache DEVE ser multiplo do Numero de conjuntos (N)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ram.Columns.Add("bloco", "Bloco");                      //
                    Ram.Columns.Add("dado", "Dado");                        // cria coluna datagrid RAM
                    Ram.Columns.Add("endereço", "Endereço");                //


                    Cache.Columns.Add("cor", "N");                          //
                    Cache.Columns.Add("tag", "Tag");                        //
                    Cache.Columns.Add("bloco", "Bloco");                    // cria coluna datagrid Cache
                    Cache.Columns.Add("hora", "Hora Carregada");            //
                    Cache.Columns.Add("ultima", "Ultima Hora Usada");       //  
                    Cache.Columns.Add("acessos", "Acessos");                //

                    WidthChanger();

                    blocos = new int[tamanhoMR / tamanhoBloco];         //numero de linhas do bloco
                    ContAcesso = new int[tamanhoMR / tamanhoBloco];     //contador de acesso para cada linha
                    DataAcesso = new string[linhasCache];               //date visita para cada linha
                    HoraCarregada = new string[linhasCache];            //


                    for (int i = 1; i <= blocos.Length; i++) //preenche o datagrid Ram
                    {
                        string data = Alfanumerico_aleatorio(tamanhoBloco);
                        ContAcesso[i - 1] = 0;
                        Ram.Rows.Add(i, data, (i - 1) * tamanhoBloco);
                        blocos[i - 1] = i - 1;
                    }

                    for (int i = 1; i <= linhasCache; i++) //cria tamanho grid cache
                    {
                        Cache.Rows.Add(null, null, null, null);
                        Cache.Rows[i].Height = 30;
                    }

                    int k = 0; //n
                    int aux = 0;
                    int contador = 0;
                    for (int i = 0; i < linhasCache / n; i++) //preenche datagrid cache
                    {
                        for (int j = 0; j < n; j++)
                        {
                            contador++;
                            if (contador == 1)
                            {
                                aux = i;
                            }
                            Cache.Rows[aux].Cells[0].Value = k;
                            aux++;
                        }
                        k++;
                    }

                    for (int i = 0; i < linhasCache; i += n) //colore N
                    {
                        CacheColorChanger(i, 0, n, linhasCache);
                    }
                }
            }
            Cache.ClearSelection();
            Ram.ClearSelection();
        }      //botao go - valida os dados digitados e se estiver tudo ok, cria os datagrids e começa o simulador

        private void Botao_Sair_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da Aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                Application.Exit();
        } //botao sair - sai do programa, ou não

        private void Botao_Limpar_Click(object sender, EventArgs e)
        {
            Limpar();
        } //botao clear - limpa tudo

        private void button1_Click(object sender, EventArgs e) //calcula a eficiencia do metodo selecionado
        {
            int c = 0, a = eficiencia, b = hits;
            string metodo = "";
            if (this.comboBox1.SelectedIndex == 0)
                metodo = comboBox1.Text;

            else if (this.comboBox1.SelectedIndex == 1)
                metodo = comboBox1.Text;

            else if (this.comboBox1.SelectedIndex == 2)
                metodo = comboBox1.Text;

            if (eficiencia == 0)
                MessageBox.Show("Use algum algorítmo antes de calcular a sua eficiência", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    c = (b * 100) / a;
                }
                catch (Exception)
                {

                }

                if (hits == 0)
                    MessageBox.Show("Eficiencia do Método " + metodo + " é: " + c + "%");

                MessageBox.Show("Eficiencia do Método " + metodo + " é: " + c + "%");
            }
        }

        #endregion

        #region Metodos de Validação

        public bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text) && this.comboBox1.SelectedIndex < 0)
            {
                return false;
            }
            return true;
        }

        public bool BlocoExisteRam(int b) //valida se o bloco existe dentro da memoria RAM.
        {
            for (int i = 0; i < tamanhoMR / tamanhoBloco; i++)
            {
                if (Convert.ToInt32(Ram.Rows[i].Cells[0].Value) == b)
                    return true;
            }
            return false;
        }

        public int BlocoExisteCache(int b)
        {
            int conjunto = b % (linhasCache / n);


            for (int i = 0; i < linhasCache; i++)
            {
                if (b == 0)
                {
                    if (Convert.ToInt32(Cache.Rows[i].Cells[0].Value) == conjunto && Convert.ToInt32(Cache.Rows[i].Cells[1].Value) == b && Cache.Rows[i].Cells[1] != null)
                    {
                        return -1;  //retorna -1 se não existe
                    }
                }
                else if (Convert.ToInt32(Cache.Rows[i].Cells[0].Value) == conjunto && Convert.ToInt32(Cache.Rows[i].Cells[1].Value) == b)
                {
                    return i; //retorna seu indice caso ele exista
                }
            }
            return -1; //retorna -1 se não existe
        }   //verifica se o bloco já existe na memoria cache

        public int IsMemoriaCacheFull(int conjunto) //Verifica se a memoria cache está cheia
        {
            for (int i = 0; i < linhasCache / n; i++)
            {
                if (Convert.ToInt32(Cache.Rows[i].Cells[0].Value) == conjunto && Cache.Rows[i].Cells[1].Value == null)
                {
                    return i; //se tiver espaço retorna onde está o null;
                }
            }
            return -1; //se tiver cheia retorna -1;
        }

        public int PegaMenorHoraCarregadaNoConjunto(int conjunto)
        {
            int i, indice = 0;
            int j, aux = -1;
            for (i = 0; i < linhasCache / n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aux++;
                    if (Convert.ToDateTime(Cache.Rows[aux].Cells[3].Value) < menor && Convert.ToInt32(Cache.Rows[i * n].Cells[0].Value) == conjunto)
                    {
                        menor = Convert.ToDateTime(Cache.Rows[aux].Cells[3].Value); //att a menor data carregada
                        indice = (i * n) + j;
                    }
                }
            }
            return indice; //retorna indice do menor valor
        } //Verifica a menor data carregada do conjunto e retorna seu indice

        public int PegaMenorHoraUsadaNoConjunto(int conjunto)
        {
            int i, indice = 0;
            int j, aux = -1;
            for (i = 0; i < linhasCache / n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aux++;
                    if (Convert.ToDateTime(Cache.Rows[aux].Cells[4].Value) < menor && Convert.ToInt32(Cache.Rows[i * n].Cells[0].Value) == conjunto)
                    {
                        menor = Convert.ToDateTime(Cache.Rows[aux].Cells[4].Value); //att a menor data usada
                        indice = (i * n) + j;
                    }
                }
            }
            return indice; //retorna indice do menor valor
        } //Verifica a menor data usada do conjunto e retorna seu indice

        public int PegaMenorContador(int conjunto) //verifica qual cell é a menos usada e retorna seu indice
        {
            int i, indice = 0;
            int j, aux = -1;
            for (i = 0; i < linhasCache / n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    aux++;
                    if (Convert.ToInt32(Cache.Rows[aux].Cells[5].Value) < menorContador && Convert.ToInt32(Cache.Rows[i * n].Cells[0].Value) == conjunto)
                    {
                        menorContador = Convert.ToInt32(Cache.Rows[aux].Cells[5].Value);
                        indice = (i * n) + j;
                    }
                }
            }
            return indice;
        }
        #endregion

        #region Algoritmos

        public void FIFO(int bloco)
        {
            eficiencia += 1;
            int cond1 = BlocoExisteCache(bloco);


            if (BlocoExisteRam(bloco))
            {
                if (cond1 != -1) //se existe na cache
                {
                    DataAcesso[cond1] = DateTime.Now.ToString();
                    Cache.Rows[cond1].Cells[4].Value = DataAcesso[cond1];

                    ContAcesso[cond1] += 1;
                    Cache.Rows[cond1].Cells[5].Value = ContAcesso[cond1];

                    HitMiss("hit", bloco);
                    hits += 1;
                }
                else //se nao existe na cache
                {
                    int cond2 = IsMemoriaCacheFull(bloco % (linhasCache / n)); //indice
                    int iRam;
                    if (cond2 > -1) //se não tiver cheia
                    {
                        for (iRam = 0; iRam < tamanhoMR / tamanhoBloco; iRam++)
                        {
                            if (Convert.ToInt32(Ram.Rows[iRam].Cells[0].Value) == bloco) //busca na bloco digitado RAM
                            {
                                Cache.Rows[cond2].Cells[1].Value = Ram.Rows[iRam].Cells[0].Value;
                                Cache.Rows[cond2].Cells[2].Value = Ram.Rows[iRam].Cells[1].Value;

                                HoraCarregada[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[3].Value = HoraCarregada[cond2];


                                DataAcesso[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[4].Value = DataAcesso[cond2];

                                ContAcesso[cond2] += 1;
                                Cache.Rows[cond2].Cells[5].Value = ContAcesso[cond2];
                                cond2 = IsMemoriaCacheFull(bloco % linhasCache);
                                break;
                            }
                        }
                        HitMiss("miss", 0);

                    }
                    else //se tiver cheia
                    {
                        int i = PegaMenorHoraCarregadaNoConjunto(bloco % (linhasCache / n));

                        for (int j = 0; j < tamanhoMR / tamanhoBloco; j++)
                        {
                            if (Convert.ToInt32(Ram.Rows[j].Cells[0].Value) == bloco) //procura bloco na ram
                            {
                                if (cond2 == -1)
                                    cond2 = 0;

                                Cache.Rows[i].Cells[1].Value = 0; //limpa
                                Cache.Rows[i].Cells[2].Value = 0; //limpa

                                Cache.Rows[i].Cells[1].Value = Ram.Rows[j].Cells[0].Value; //add
                                Cache.Rows[i].Cells[2].Value = Ram.Rows[j].Cells[1].Value; //add

                                HoraCarregada[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[3].Value = HoraCarregada[i];


                                DataAcesso[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[4].Value = DataAcesso[i];

                                Cache.Rows[i].Cells[5].Value = 1;

                                Refresh();
                            }
                        }
                        HitMiss("miss", 0);
                    }
                }
            }
            else
                MessageBox.Show("Bloco digitado NÃO existe na RAM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Refresh();
        }

        public void LRU(int bloco)
        {
            eficiencia += 1;
            int cond1 = BlocoExisteCache(bloco);

            if (BlocoExisteRam(bloco))
            {
                if (cond1 != -1) //se existe na cache
                {
                    DataAcesso[cond1] = DateTime.Now.ToString();
                    Cache.Rows[cond1].Cells[4].Value = DataAcesso[cond1];

                    ContAcesso[cond1] += 1;
                    Cache.Rows[cond1].Cells[5].Value = ContAcesso[cond1];

                    HitMiss("hit", bloco);
                    hits += 1;
                }
                else //se nao existe na cache
                {
                    int cond2 = IsMemoriaCacheFull(bloco % (linhasCache / n)); //indice
                    int iRam;
                    if (cond2 > -1) //se não tiver cheia
                    {
                        for (iRam = 0; iRam < tamanhoMR / tamanhoBloco; iRam++)
                        {
                            if (Convert.ToInt32(Ram.Rows[iRam].Cells[0].Value) == bloco) //busca na bloco digitado RAM
                            {
                                Cache.Rows[cond2].Cells[1].Value = Ram.Rows[iRam].Cells[0].Value;
                                Cache.Rows[cond2].Cells[2].Value = Ram.Rows[iRam].Cells[1].Value;

                                HoraCarregada[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[3].Value = HoraCarregada[cond2];


                                DataAcesso[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[4].Value = DataAcesso[cond2];

                                ContAcesso[cond2] += 1;
                                Cache.Rows[cond2].Cells[5].Value = ContAcesso[cond2];
                                cond2 = IsMemoriaCacheFull(bloco % linhasCache);
                                break;
                            }
                        }
                        HitMiss("miss", 0);
                    }
                    else //se tiver cheia
                    {
                        int i = PegaMenorHoraUsadaNoConjunto(bloco % (linhasCache / n));

                        for (int j = 0; j < tamanhoMR / tamanhoBloco; j++)
                        {
                            if (Convert.ToInt32(Ram.Rows[j].Cells[0].Value) == bloco) //procura bloco na ram
                            {
                                if (cond2 == -1)
                                    cond2 = 0;

                                Cache.Rows[i].Cells[1].Value = 0; //limpa
                                Cache.Rows[i].Cells[2].Value = 0; //limpa

                                Cache.Rows[i].Cells[1].Value = Ram.Rows[j].Cells[0].Value; //add
                                Cache.Rows[i].Cells[2].Value = Ram.Rows[j].Cells[1].Value; //add

                                HoraCarregada[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[3].Value = HoraCarregada[i];


                                DataAcesso[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[4].Value = DataAcesso[i];

                                Cache.Rows[i].Cells[5].Value = 1;

                                Refresh();
                            }
                        }
                        HitMiss("miss", 0);
                    }
                }
            }
            else
                MessageBox.Show("Bloco digitado NÃO existe na RAM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Refresh();
        }

        public void LFU(int bloco)
        {
            int cond1 = BlocoExisteCache(bloco);


            if (BlocoExisteRam(bloco))
            {
                if (cond1 != -1) //se existe na cache
                {
                    DataAcesso[cond1] = DateTime.Now.ToString();
                    Cache.Rows[cond1].Cells[4].Value = DataAcesso[cond1];

                    ContAcesso[cond1] += 1;
                    Cache.Rows[cond1].Cells[5].Value = ContAcesso[cond1];

                    HitMiss("hit", bloco);
                    hits += 1;
                }
                else //se nao existe na cache
                {
                    int cond2 = IsMemoriaCacheFull(bloco % (linhasCache / n)); //indice
                    int iRam;
                    if (cond2 > -1) //se não tiver cheia
                    {
                        for (iRam = 0; iRam < tamanhoMR / tamanhoBloco; iRam++)
                        {
                            if (Convert.ToInt32(Ram.Rows[iRam].Cells[0].Value) == bloco) //busca na bloco digitado RAM
                            {
                                Cache.Rows[cond2].Cells[1].Value = Ram.Rows[iRam].Cells[0].Value;
                                Cache.Rows[cond2].Cells[2].Value = Ram.Rows[iRam].Cells[1].Value;

                                HoraCarregada[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[3].Value = HoraCarregada[cond2];


                                DataAcesso[cond2] = DateTime.Now.ToString();
                                Cache.Rows[cond2].Cells[4].Value = DataAcesso[cond2];

                                ContAcesso[cond2] += 1;
                                Cache.Rows[cond2].Cells[5].Value = ContAcesso[cond2];
                                cond2 = IsMemoriaCacheFull(bloco % linhasCache);
                                break;
                            }
                        }
                        HitMiss("miss", 0);
                    }
                    else //se tiver cheia
                    {
                        int i = PegaMenorContador(bloco % (linhasCache / n));

                        for (int j = 0; j < tamanhoMR / tamanhoBloco; j++)
                        {
                            if (Convert.ToInt32(Ram.Rows[j].Cells[0].Value) == bloco) //procura bloco na ram
                            {
                                if (cond2 == -1)
                                    cond2 = 0;

                                Cache.Rows[i].Cells[1].Value = 0; //limpa
                                Cache.Rows[i].Cells[2].Value = 0; //limpa

                                Cache.Rows[i].Cells[1].Value = Ram.Rows[j].Cells[0].Value; //add
                                Cache.Rows[i].Cells[2].Value = Ram.Rows[j].Cells[1].Value; //add

                                HoraCarregada[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[3].Value = HoraCarregada[i];


                                DataAcesso[i] = DateTime.Now.ToString();
                                Cache.Rows[i].Cells[4].Value = DataAcesso[i];

                                Cache.Rows[i].Cells[5].Value = 1;

                                Refresh();
                            }
                        }
                        HitMiss("miss", 0);
                    }
                }
            }
            else
                MessageBox.Show("Bloco digitado NÃO existe na RAM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Refresh();
        }
        #endregion

        #region metodos que eu nao sei dar nome
        public void WidthChanger()
        {
            this.Cache.Columns[0].Width = 40;
            this.Cache.Columns[1].Width = 40;
        } //muda width das colunas

        public string Alfanumerico_aleatorio(int tamanho) //gera aleatorio de acordo com o tamanho da memoria
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcvwxyz";
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[r.Next(s.Length)])
                          .ToArray());
            return result;
        }

        async public void HitMiss(string v, int b)
        {
            if (v == "hit")
            {
                for (int i = 0; i < linhasCache; i++)
                {
                    if (Convert.ToInt32(Cache.Rows[i].Cells[1].Value) == b)
                    {
                        this.hit_miss.Text = "Hit";
                        this.hit_miss.Show();
                        await Task.Delay(1500);
                        this.hit_miss.Hide();
                        this.hit_miss.Text = "";
                        break;
                    }
                }
            }
            else
            {
                this.hit_miss.Text = "Miss";
                this.hit_miss.Show();
                await Task.Delay(1500);
                this.hit_miss.Hide();
                this.hit_miss.Text = "";
            }
        }

        public void Limpar()
        {

            Cache.Rows.Clear();             //
            Cache.DataSource = null;        //
            Cache.Columns.Clear();          // limpa todo o datagrid da cache.
            Cache.Refresh();                //
            linhasCache = 0;                //

            Ram.Rows.Clear();               //
            Ram.DataSource = null;          //  
            Ram.Columns.Clear();            // limpa todo o datagrid da ram.
            Ram.Refresh();                  //
            tamanhoMR = 0;                  //

            tamanhoBloco = 0;

            this.labelSequencia.Text = null;

            eficiencia = 0;
            hits = 0;

            menorContador = 0;
            j = 0;
            n = 0;
            anterior = 0;
            menor = Convert.ToDateTime(null);

            for (int i = 0; i < blocos.Length; i++)
            {
                blocos[i] = 0;
            }

            for (int i = 0; i < DataAcesso.Length; i++)
            {
                DataAcesso[i] = "";
            }

            for (int i = 0; i < ContAcesso.Length; i++)
            {
                ContAcesso[i] = 0;
            }

            for (int i = 0; i < HoraCarregada.Length; i++)
            {
                HoraCarregada[i] = null;
            }

        } //metodo pra limpar

        public void CacheColorChanger(int roll, int cell, int n, int linhas)
        {
            int aux = r.Next(8);
            int aux2 = roll;

            if (anterior == aux)
            {
                while (anterior == aux)
                {
                    aux = r.Next(4);
                }
            }

            if (aux == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Red;
                    aux2++;
                }
                anterior = aux;
            }
            if (aux == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Blue;
                    aux2++;
                }
                anterior = aux;
            }
            if (aux == 2)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Yellow;
                    aux2++;
                }
                anterior = aux;
            }
            if (aux == 3)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Purple;
                    aux2++;
                }
                anterior = aux;
            }
            if (aux == 4)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Green;
                    aux2++;
                }
                anterior = aux;
            }

            if (aux == 5)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Magenta;
                    aux2++;
                }
                anterior = aux;
            }

            if (aux == 6)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Aqua;
                    aux2++;
                }
                anterior = aux;
            }

            if (aux == 7)
            {
                for (int i = 0; i < n; i++)
                {
                    if (aux2 > linhas)
                    {
                        break;
                    }
                    Cache.Rows[aux2].Cells[cell].Style.BackColor = Color.Brown;
                    aux2++;
                }
                anterior = aux;
            }
        } //muda cor de NC
        #endregion
    }
}



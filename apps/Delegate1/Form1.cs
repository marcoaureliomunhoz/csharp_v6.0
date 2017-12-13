using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegate1
{
    #region delegate

    //olha como é simples declarar um delegate
    //por baixo dos panos o C# gera uma classe
    //que aceita e gerencia métodos com a assinatura abaixo
    public delegate void DelegLog(string log);

    #endregion

    #region MinhaThread

    public class MinhaThread
    {
        private DelegLog _deleg;

        public MinhaThread(DelegLog deleg)
        {
            _deleg = deleg;
            Thread thread = new Thread(Executar);
            thread.Start();
        }

        private void Executar()
        {
            string log = "";
            for (int i = 1; i <= 10; i++)
            {
                //processamento - 10 segundos
                Thread.Sleep(1000);
                //log
                log += i.ToString() + " => " + DateTime.Now.ToString() + "\n";
            }
            //aqui verificamos se o delegate de fato possui um método delegado
            if (_deleg.Method != null)
            {
                //forma curta de se invocar um delegate
                _deleg(log);
                //forma explícita de se invocar um delegate
                //_deleg.Invoke(log); 
            }
        }

    }

    #endregion

    #region Aplicação

    public partial class Form1 : Form
    {
        private bool _processando = false;

        public Form1()
        {
            InitializeComponent();
        }

        //aqui é o momento em que o usuário aciona uma operação que desencadeia uma série de operações
        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (!_processando)
            {
                _processando = true;

                //o parâmetro do construtor de MinhaThread espera um delegate
                //neste caso o delegate aponta para apenas um método
                //portanto basta passar o nome do método que nos bastidores o C# realiza o 
                //trabalho pesado
                MinhaThread mt = new MinhaThread(GravarLogEmBD);

                //poderíamos usar a forma explícita, mas a forma anterior (resumida) é mais 
                //elegante quando o delegate aponta para apenas um método
                //MinhaThread mt = new MinhaThead(new DelegLog(GravarLogEmBD));

                //se fosse necessário passar para a MinhaThread um delegate que aponta para vários 
                //métodos teríamos que usar a forma explícita 
            }
        }

        //aqui o método para o qual será delegado
        private void GravarLogEmBD(string log)
        {
            //aqui aciona a camada de dados
            //...
            //aqui avisa o usuário
            MessageBox.Show("Blá blá blá blá!");
            _processando = false;
        }
    }

    #endregion
}

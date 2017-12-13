using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloPadradoDeEventos1
{
    public class AlteracaoCorEventArgs : EventArgs
    {
        /* as propriedades públicas são acessíveis ao mundo externo */
        public string CorAnterior { get; set; }

        public AlteracaoCorEventArgs(string corAnterior)
        {
            CorAnterior = corAnterior;
        }
    }

    public class MeuBotao : Button
    {
        //public
        /* classe que faz a intermediação entre MeuBotao e o mundo externo */
        public event EventHandler<AlteracaoCorEventArgs> AlteracaoCor;

        //protected        
        /* método emissor primário */
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            string corAnterior = this.BackColor.ToString();

            this.BackColor = Color.FromArgb(r, g, b);
            this.ForeColor = Color.FromArgb(g, b, r);

            OnAlteracaoCor(new AlteracaoCorEventArgs(corAnterior));
        }

        /* método emissor final */
        protected virtual void OnAlteracaoCor(AlteracaoCorEventArgs e)
        {
            if (AlteracaoCor != null)
            {
                AlteracaoCor(this, e);
            }
        }

        //private
        private Random random = new Random();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class KlasaTestowa
    {
        private int nrPojazdu;
        private string markaPojazdu;
        private string modelPojazdu;
        private string opiekunPojazdu;

        public KlasaTestowa(int _nrPojazdu, string _markaPojazdu, string _modelPojazdu, string _opiekunPojazdu)
        {
            this.nrPojazdu = _nrPojazdu;
            this.markaPojazdu = _markaPojazdu;
            this.modelPojazdu = _modelPojazdu;
            this.opiekunPojazdu = _opiekunPojazdu;

        }

        public int NrPojazdu
        {
            get
            {
                return nrPojazdu;
            }
            set
            {
                nrPojazdu = value;
            }
        }

        public string MarkaPojazdu
        {
            get
            {
                return markaPojazdu;
            }
            set
            {
                markaPojazdu = value;
            }
        }

        public string ModelPojazdu
        {
            get
            {
                return modelPojazdu;
            }
            set
            {
                modelPojazdu = value;
            }
        }

        public string OpiekunPojazdu
        {
            get
            {
                return opiekunPojazdu;
            }
            set
            {
                opiekunPojazdu = value;
            }
        }
    }
}

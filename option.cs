using System;
using System.Collections.Generic;
using System.Text;

namespace filliere
{
    class Option
    {
        public String nom_option;
        public int places_dispo;



        public Option()
        {

        }
        public Option(String nomChoix, int placesFiliereGLABDASR)
        {
            this.nom_option = nomChoix;
            this.places_dispo = placesFiliereGLABDASR;
        }

    }

}

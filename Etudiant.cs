using System;
using System.Collections.Generic;
using System.Text;

namespace filliere
{
    //herite de la classe Option
    class Etudiant : Option
    {

        private string nom;
        private string prenom;
        private float note;


        public Etudiant() : base()
        {

        }
        public Etudiant(string nom, string prenom, float note, String nom_option, int places_disponibles) : base(nom_option, places_disponibles)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.note = note;

        }
        public Etudiant(string nom, string prenom, float note)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.note = note;

        }


        public void Affectation()
        {
            //le nombre des places dispon pour chaque Option
            Option GL = new Option();
            GL.nom_option = "GL";
            Console.Write("Entrez le nombre de places disponibles dans GL : \t");
            GL.places_dispo = int.Parse(Console.ReadLine());

            Option ABD = new Option();
            ABD.nom_option = "ABD";
            Console.Write("Entrez le nombre de places disponibles dans ABD : \t");
            ABD.places_dispo = int.Parse(Console.ReadLine());

            Option ASR = new Option();
            ASR.nom_option = "ASR";
            Console.Write("Entrez le nombre de places disponibles dans ASR : \t");
            ASR.places_dispo = int.Parse(Console.ReadLine());

            //le nombre total des etudiants GI
            places_dispo = GL.places_dispo + ABD.places_dispo + ASR.places_dispo;
            Console.WriteLine("\nle nombre  des etudiant  la filière informatiques deuxieme annee est : \t" + places_dispo);
            Console.WriteLine();

            //stocker les informations de chaque etudiant dans un tuplet 
            var tupleList = new List<Tuple<Etudiant, String, String, String>>();

            // Affectation 
            for (int i = 0; i < places_dispo; i++)
            {
                Console.Write("Entrer nom  \t");
                nom = (Console.ReadLine());
                Console.Write("Entrer prenom  \t");
                prenom = (Console.ReadLine());

                try
                {
                    Console.Write("Entrer la note\t");
                    note = float.Parse(Console.ReadLine());
                }
                //exeption gere si la note est valide ou pas 
                catch (Exception e)
                {
                    throw;
                    Console.WriteLine("Error entrer un nombre");
                }

                Console.Write("Entrer premire choix GL ou ABD ou ASR :  \t");
                String choix1 = Console.ReadLine();
                Console.Write("Entrer deuxieme choix  GL ou ABD ou ASR :  \t");
                String choix2 = Console.ReadLine();
                Console.Write("Entrer troisieme choix GL ou ABD ou ASR :  \t");
                String choix3 = Console.ReadLine();
                Console.WriteLine();

                Etudiant etudiant1 = new Etudiant(nom, prenom, note);
                var Et1 = Tuple.Create(etudiant1, choix1, choix2, choix3);
                tupleList.Add(Et1);

            }
            //stocker les options des etudiants selon leurs choix 
            var listGL = new List<Etudiant>();
            var listABD = new List<Etudiant>();
            var listASR = new List<Etudiant>();

            //triage
            tupleList.Sort((x, y) =>
            {
                int result = y.Item1.note.CompareTo(x.Item1.note);
                return result == 0 ? y.Item2.CompareTo(x.Item2) : result;
            });


            //un test si la filiere remplis tous les places disponibles en traite le deuxieme choix de l'option...
            for (int i = 0; i < places_dispo; i++)
            {

                switch (tupleList[i].Item2)
                {
                    //option GL
                    case "GL":
                        if (GL.places_dispo > listGL.Count)
                        {
                            Etudiant item1 = tupleList[i].Item1;
                            listGL.Add(item1);
                        }

                        else
                        {
                            switch (tupleList[i].Item3)
                            {
                                case "ABD":
                                    if (ABD.places_dispo > listABD.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listABD.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "ASR" && ASR.places_dispo > listASR.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listASR.Add(item3);
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (ASR.places_dispo > listASR.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listASR.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "ABD" && ABD.places_dispo > listABD.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listABD.Add(item3);
                                        }
                                    }
                                    break;
                            }

                        }
                        break;


                    //option ABD
                    case "ABD":
                        if (ABD.places_dispo > listABD.Count)
                        {
                            Etudiant item1 = tupleList[i].Item1;
                            listABD.Add(item1);
                        }
                        else
                        {

                            switch (tupleList[i].Item3)
                            {
                                case "GL":
                                    if (GL.places_dispo > listGL.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listGL.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "ASR" && ASR.places_dispo > listASR.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listASR.Add(item3);
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (ASR.places_dispo > listASR.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listASR.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "GL" && GL.places_dispo > listGL.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listGL.Add(item3);
                                        }
                                    }
                                    break;
                            }

                        }
                        break;


                    //option ASR
                    case "ASR":
                        if (ASR.places_dispo > listASR.Count)
                        {
                            Etudiant item1 = tupleList[i].Item1;
                            listASR.Add(item1);
                        }
                        else
                        {

                            switch (tupleList[i].Item3)
                            {
                                case "ABD":
                                    if (ABD.places_dispo > listABD.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listABD.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "GL" && GL.places_dispo > listGL.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listGL.Add(item3);
                                        }
                                    }
                                    break;

                                case "GL":
                                    if (GL.places_dispo > listGL.Count)
                                    {
                                        Etudiant item2 = tupleList[i].Item1;
                                        listGL.Add(item2);
                                    }
                                    else
                                    {
                                        if (tupleList[i].Item4 == "ABD" && ABD.places_dispo > listABD.Count)
                                        {
                                            Etudiant item3 = tupleList[i].Item1;
                                            listABD.Add(item3);
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                }
            }


            //L'AFFICHAGE
            Console.WriteLine("\n********************************************************************************************** ");
            Console.WriteLine("\n\nla liste des etudiants option GL:");
            Console.WriteLine("\n" + "Nom" + "\t" + "Prenom" + "\t" + "Note");
            foreach (Etudiant i in listGL)
            {
                Console.WriteLine(i.nom + "\t" + i.prenom + "\t" + i.note);
            }
            Console.WriteLine("\n********************************************************************************************** ");
            Console.WriteLine("\nla liste des etudiants option ABD:");
            Console.WriteLine("\n" + "Nom" + "\t" + "Prenom" + "\t" + "Note");
            foreach (Etudiant i in listABD)
            {
                Console.WriteLine(i.nom + "\t" + i.prenom + "\t" + i.note);
            }
            Console.WriteLine("\n********************************************************************************************** ");
            Console.WriteLine("\nla liste des etudiants option ASR :");
            Console.WriteLine("\n" + "Nom" + "\t" + "Prenom" + "\t" + "Note");
            foreach (Etudiant i in listASR)
            {
                Console.WriteLine(i.nom + "\t" + i.prenom + "\t" + i.note);
            }
        }



    }
}

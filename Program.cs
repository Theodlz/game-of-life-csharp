using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsilvGui;

namespace JeuDeLaVie
{
    class Program
    {

        static int[,] Grille(int ligne, int colonne, double remplissage)
        {
            //création de la grille de jeu
            int[,] grille = new int[ligne, colonne];
            int totalRemplissage = Convert.ToInt16(remplissage * (colonne * ligne));
            Random rand = new Random();

            for (int h = 0; h < totalRemplissage; h++)
            //attribution de cellules vivantes à des cases de manière aléatoire 
            {
                int i = rand.Next(0, ligne);
                int j = rand.Next(0, colonne);
                if (grille[i, j] == 0)
                {
                    grille[i, j] = 1;
                }
                else
                //si la case tiré au sort possède déjà une cellule vivante, on permet un nouveau tirage au sort
                {
                    h--;
                }
            }
            return grille;
        }

        static void AfficherGrille(int[,] grille)
        //affichage de la grille de jeu
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {

                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == 0)
                    {
                        //cellule morte
                        Console.Write(" . ");


                    }
                    if (grille[i, j] == 1)
                    {
                        //cellule vivante population 1
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" # ");
                        Console.ResetColor();


                    }
                    if (grille[i, j] == 4)
                    {
                        //cellule vivante population 2
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" # ");
                        Console.ResetColor();


                    }
                    if (grille[i, j] == 3)
                    {
                        //cellule population 1 qui va mourir
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" * ");
                        Console.ResetColor();


                    }
                    if (grille[i, j] == 2)
                    {
                        //cellule population 1 qui va naitre
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" - ");
                        Console.ResetColor();
                    }
                    if (grille[i, j] == 5)
                    {
                        //cellule population 2 qui va naitre
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" - ");
                        Console.ResetColor();
                    }

                    if (grille[i, j] == 6)
                    {
                        //cellule population 2 qui va mourir
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" * ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        static int[,] NewGrille(int[,] grille)
        {
            int[,] nouvelleGrille = new int[grille.GetLength(0), grille.GetLength(1)];
            for (int i = 0; i < nouvelleGrille.GetLength(0); i++)
            {
                for (int j = 0; j < nouvelleGrille.GetLength(1); j++) //cette boucle for et celle du dessus permettent de faire passer le curseur sur chaque case de la matrice
                {
                    int compteur = 0;
                    int numLigne = i;
                    int numColonne = j;
                    for (numLigne = i - 1; numLigne <= i + 1; numLigne++)
                    {
                        for (numColonne = j - 1; numColonne <= j + 1; numColonne++) //cette boucle for et celle du dessus permettent un scan des 8 cases autour du curseur
                        {
                            int numColonne2 = numColonne;
                            int numLigne2 = numLigne;
                            if (numLigne == -1)//si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                            {
                                numLigne = grille.GetLength(0) - 1;
                            }
                            if (numLigne == grille.GetLength(0))//si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                            {
                                numLigne = 0;
                            }
                            if (numColonne == -1)//si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                            {
                                numColonne = grille.GetLength(1) - 1;
                            }
                            if (numColonne == grille.GetLength(1))//si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                            {
                                numColonne = 0;
                            }
                            if (grille[numLigne, numColonne] == 1)
                            {
                                compteur++;
                            }
                            numLigne = numLigne2;
                            numColonne = numColonne2;
                        }
                    }

                    nouvelleGrille[i, j] = grille[i, j];
                    //application des différentes règles du jeu de la vie
                    if (grille[i, j] == 1)
                    {
                        compteur--;
                    }

                    if (compteur < 2 || compteur > 3)
                    {
                        nouvelleGrille[i, j] = 0;
                    }

                    if (compteur == 3)
                    {
                        nouvelleGrille[i, j] = 1;
                    }
                }
            }

            return nouvelleGrille;
        }
        static int[,] GrilleEtatInter(int[,] grille)
        {
            int[,] grilleEtatInter = new int[grille.GetLength(0), grille.GetLength(1)];
            for (int i = 0; i < grilleEtatInter.GetLength(0); i++)
            {
                for (int j = 0; j < grilleEtatInter.GetLength(1); j++) //cette boucle for et celle du dessus permettent de faire passer le curseur sur chaque case de la matrice
                {
                    int compteur = 0;
                    int numLigne = i;
                    int numColonne = j;
                    for (numLigne = i - 1; numLigne <= i + 1; numLigne++)
                    {
                        for (numColonne = j - 1; numColonne <= j + 1; numColonne++) //cette boucle for et celle du dessus permettent un scan des 8 cases autour du curseur
                        {
                            int numColonne2 = numColonne;
                            int numLigne2 = numLigne;
                            if (numLigne == -1)//si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                            {
                                numLigne = grille.GetLength(0) - 1;
                            }
                            if (numLigne == grille.GetLength(0))//si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                            {
                                numLigne = 0;
                            }
                            if (numColonne == -1)//si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                            {
                                numColonne = grille.GetLength(1) - 1;
                            }
                            if (numColonne == grille.GetLength(1))//si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                            {
                                numColonne = 0;
                            }
                            if (grille[numLigne, numColonne] == 1)
                            {
                                compteur++;
                            }
                            numLigne = numLigne2;
                            numColonne = numColonne2;
                        }
                    }

                    grilleEtatInter[i, j] = grille[i, j];

                    if (grille[i, j] == 1)
                    {
                        compteur--;
                    }
                    //affectation des états "cellule va naître" (=2) et "cellule va mourir" (=3) en appliquant les règles du jeu de la vie 
                    if ((compteur < 2 || compteur > 3) && grille[i, j] == 1)
                    {
                        grilleEtatInter[i, j] = 3;
                    }

                    if (compteur == 3 && grille[i, j] == 0)
                    {
                        grilleEtatInter[i, j] = 2;
                    }
                }
            }
            return grilleEtatInter;
        }

        static int[,] Grille1v1(int ligne, int colonne, double remplissage)
        {
            int[,] grille = new int[ligne, colonne];
            int totalRemplissage = Convert.ToInt16(remplissage * (colonne * ligne) / 2);
            Random rand = new Random();

            //remplissage de cases aléatoirement choisies par des cellules vivantes de la population 1 (première boucle for) puis de la population 2 (deuxième boucle for)
            for (int k = 0; k < totalRemplissage; k++)
            {
                int i = rand.Next(0, ligne);
                int j = rand.Next(0, colonne);
                if (grille[i, j] == 0)
                {
                    grille[i, j] = 1; //état représentant une cellule vivante de la population 1
                }
                else
                {
                    k--;
                }
            }
            for (int k = 0; k < totalRemplissage; k++)
            {
                int i = rand.Next(0, ligne);
                int j = rand.Next(0, colonne);
                if (grille[i, j] == 0)
                {
                    grille[i, j] = 4; //état représentant une cellule vivante de la population 2
                }
                else
                {
                    k--;
                }
            }
            return grille;
        }

        static int[,] NewGrille1v1(int[,] grille, string varianteR4B)
        {
            int[,] nouvelleGrille = new int[grille.GetLength(0), grille.GetLength(1)];
            for (int i = 0; i < nouvelleGrille.GetLength(0); i++)
            {
                for (int j = 0; j < nouvelleGrille.GetLength(1); j++) //cette boucle for et celle du dessus permettent de faire passer le curseur sur chaque case de la matrice
                {
                    int compteurFamille1Rang1 = 0;
                    int compteurFamille2Rang1 = 0;
                    int numLigne = i;
                    int numColonne = j;

                    //SCAN DE RANG 1
                    for (numLigne = i - 1; numLigne <= i + 1; numLigne++)
                    {
                        for (numColonne = j - 1; numColonne <= j + 1; numColonne++) //cette boucle for et celle du dessus permettent un scan des 8 cases autour du curseur
                        {
                            int numColonne2 = numColonne;
                            int numLigne2 = numLigne;
                            if (numLigne == grille.GetLength(0))//si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                            {
                                numLigne = 0;
                            }
                            if (numLigne == -1)//si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                            {
                                numLigne = grille.GetLength(0) - 1;
                            }
                            if (numColonne == -1)//si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                            {
                                numColonne = grille.GetLength(1) - 1;
                            }
                            if (numColonne == grille.GetLength(1))//si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                            {
                                numColonne = 0;
                            }
                            if (grille[numLigne, numColonne] == 1)
                            {
                                compteurFamille1Rang1++;
                            }
                            if (grille[numLigne, numColonne] == 4)
                            {
                                compteurFamille2Rang1++;
                            }
                            numLigne = numLigne2;
                            numColonne = numColonne2;
                        }
                    }


                    if (grille[i, j] == 1)
                    {
                        compteurFamille1Rang1--;
                    }
                    if (grille[i, j] == 4)
                    {
                        compteurFamille2Rang1--;
                    }
                    nouvelleGrille[i, j] = grille[i, j];

                    if ((grille[i, j] == 1) && (compteurFamille1Rang1 < 2))
                        nouvelleGrille[i, j] = 0;
                    if ((grille[i, j] == 4) && (compteurFamille2Rang1 < 2))
                        nouvelleGrille[i, j] = 0;

                    if ((grille[i, j] == 1) && (compteurFamille1Rang1 > 3))
                        nouvelleGrille[i, j] = 0;
                    if ((grille[i, j] == 4) && (compteurFamille2Rang1 > 3))
                        nouvelleGrille[i, j] = 0;

                    //application de la règle R4B
                    if ((grille[i, j] == 0) && (compteurFamille1Rang1 == 3) && (compteurFamille2Rang1 == 3))
                    {
                        if (RegleR4B(grille, i, j) > 0) //si population 1 > population 2 au voisinage de rang 2 ...
                            grille[i, j] = 1;
                        if (RegleR4B(grille, i, j) < 0) //si population 2 > population 1 au voisinage de rang 2 ...
                            grille[i, j] = 4;
                        if (RegleR4B(grille, i, j) == 0) //si égalité des deux populations au voisinage de rang 2 ...
                        {
                            if (CompteurCellulesVivantes1v1(grille) > 0) //si population 1 > population 2 sur le total de la grille
                                grille[i, j] = 1;
                            if (CompteurCellulesVivantes1v1(grille) < 0) //si population 2 > population 1 sur le total de la grille
                                grille[i, j] = 4;
                            if (varianteR4B == "oui" && CompteurCellulesVivantes1v1(grille) == 0) //si le bonus n°2 est activé et égalité deux populations sur le total de la grille ...
                            {
                                Random rand = new Random();
                                int random = rand.Next(1, 3);
                                if (random == 1)
                                {
                                    grille[i, j] = 1;
                                }
                                if (random == 2)
                                {
                                    grille[i, j] = 4;
                                }
                            }
                        }
                    }

                    if ((grille[i, j] == 0) && (compteurFamille1Rang1 == 3))
                        nouvelleGrille[i, j] = 1;
                    if ((grille[i, j] == 0) && (compteurFamille2Rang1 == 3))
                        nouvelleGrille[i, j] = 4;
                }
            }
            return nouvelleGrille;
        }

        static int CompteurCellulesVivantes1v1(int[,] grille)
        {
            int compteur = 0;
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == 1)
                    {
                        compteur++; //quand le curseur rencontre une cellule vivante de la population 1, le compteur est incrémenté
                    }
                    if (grille[i, j] == 4)
                    {
                        compteur--; //quand le curseur rencontre une cellule vivante de la population 2, le compteur est décrémenté
                    }
                    //si compteur>0 alors il y a plus de cellules vivantes de la population 1 dans la grille
                    //si compteur<0 alors il y a plus de cellules vivantes de la population 2 dans la grille
                    //si compteur=0 alors il y a autant de cellules vivantes des deux populations dans la grille
                }
            }
            return compteur;
        }

        static int CompteurCellulesVivantes(int[,] grille)
        //compte le nombre total de cellules vivantes présentes dans la grille
        {
            int compteur = 0;
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == 1 || grille[i, j] == 4)
                    {

                        compteur++;
                    }
                }
            }
            return compteur;
        }

        static int RegleR4B(int[,] grille, int i, int j)
        //compteur des cellules vivantes de chaque population présentes sur les 24 cases autour du curseur
        {
            int compteur = 0;
            for (int numLigne = i - 2; numLigne <= i + 2; numLigne++)
            {
                for (int numColonne = j - 2; numColonne <= j + 2; numColonne++) //cette boucle for et celle du dessus permettent un scan des 24 cases autour du curseur (scan de rang 2)
                {
                    int numColonne2 = numColonne;
                    int numLigne2 = numLigne;
                    if (numLigne == grille.GetLength(0))//si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                    {
                        numLigne = 0;
                    }
                    if (numLigne == grille.GetLength(0) + 1)//si le curseur de scan est tout en bas de la matrice, la seconde ligne en dessous du curseur passe en haut de la matrice, à la deuxième ligne
                    {
                        numLigne = 1;
                    }
                    if (numLigne == -1)//si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                    {
                        numLigne = grille.GetLength(0) - 1;
                    }
                    if (numLigne == -2)//si le curseur de scan est tout en haut de la matrice, la seconde ligne au-dessus du curseur passe en bas de la matrice, à l'avant dernière ligne
                    {
                        numLigne = grille.GetLength(0) - 2;
                    }
                    if (numColonne == -1)//si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                    {
                        numColonne = grille.GetLength(1) - 1;
                    }
                    if (numColonne == -2)//si le curseur de scan est tout à gauche de la matrice, la seconde colonne à gauche du curseur passe à droite de la matrice, à l'avant-dernière colonne
                    {
                        numColonne = grille.GetLength(1) - 2;
                    }
                    if (numColonne == grille.GetLength(1))//si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                    {
                        numColonne = 0;
                    }
                    if (numColonne == grille.GetLength(1) + 1)//si le curseur de scan est tout à droite de la matrice, la seconde colonne à droite du curseur passe à gauche de la matrice, à la seconde colonne 
                    {
                        numColonne = 1;
                    }

                    if (grille[numLigne, numColonne] == 1)
                    {
                        compteur++;
                    }
                    if (grille[numLigne, numColonne] == 4)
                    {
                        compteur--;
                    }
                    numLigne = numLigne2;
                    numColonne = numColonne2;
                }
            }
            return compteur;
        }

        static int[,] GrilleEtatInter1v1(int[,] grille)
        {
            int[,] grilleEtatInter1v1 = new int[grille.GetLength(0), grille.GetLength(1)];
            for (int i = 0; i < grilleEtatInter1v1.GetLength(0); i++)
            {
                for (int j = 0; j < grilleEtatInter1v1.GetLength(1); j++) //cette boucle for et celle du dessus permettent de faire passer le curseur sur chaque case de la matrice
                {
                    int compteurFamille1Rang1 = 0;
                    int compteurFamille2Rang1 = 0;
                    int numLigne = i;
                    int numColonne = j;

                    //SCAN DE RANG 1
                    for (numLigne = i - 1; numLigne <= i + 1; numLigne++)
                    {
                        for (numColonne = j - 1; numColonne <= j + 1; numColonne++) //cette boucle for et celle du dessus permettent un scan des 8 cases autour du curseur
                        {
                            int numColonne2 = numColonne;
                            int numLigne2 = numLigne;
                            if (numLigne == grille.GetLength(0))//si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                            {
                                numLigne = 0;
                            }
                            if (numLigne == -1)//si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                            {
                                numLigne = grille.GetLength(0) - 1;
                            }
                            if (numColonne == -1)//si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                            {
                                numColonne = grille.GetLength(1) - 1;
                            }
                            if (numColonne == grille.GetLength(1))//si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                            {
                                numColonne = 0;
                            }
                            if (grille[numLigne, numColonne] == 1)
                            {
                                compteurFamille1Rang1++;
                            }
                            if (grille[numLigne, numColonne] == 4)
                            {
                                compteurFamille2Rang1++;
                            }
                            numLigne = numLigne2;
                            numColonne = numColonne2;
                        }
                    }


                    if (grille[i, j] == 1)
                    {
                        compteurFamille1Rang1--;
                    }
                    if (grille[i, j] == 4)
                    {
                        compteurFamille2Rang1--;
                    }
                    grilleEtatInter1v1[i, j] = grille[i, j];

                    //application des règles du jeu de la vie
                    if ((grille[i, j] == 1) && (compteurFamille1Rang1 < 2))
                        grilleEtatInter1v1[i, j] = 3; //la valeur 3 est associé à l'état "cellule vivante population 1 qui va mourir"
                    if ((grille[i, j] == 4) && (compteurFamille2Rang1 < 2))
                        grilleEtatInter1v1[i, j] = 6; //la valeur 6 est associé à l'état "cellule vivante population 2 qui va mourir"

                    if ((grille[i, j] == 1) && (compteurFamille1Rang1 > 3))
                        grilleEtatInter1v1[i, j] = 3;
                    if ((grille[i, j] == 4) && (compteurFamille2Rang1 > 3))
                        grilleEtatInter1v1[i, j] = 6;


                    if ((grille[i, j] == 0) && (compteurFamille1Rang1 == 3) && (compteurFamille2Rang1 == 3))
                    {
                        if (RegleR4B(grille, i, j) > 0)
                            grilleEtatInter1v1[i, j] = 2; //la valeur 2 est associé à l'état "cellule morte population 1 qui va naître"
                        if (RegleR4B(grille, i, j) < 0)
                            grilleEtatInter1v1[i, j] = 5; //la valeur 5 est associé à l'état "cellule morte population 2 qui va naître"
                        if (RegleR4B(grille, i, j) == 0)
                        {
                            if (CompteurCellulesVivantes1v1(grille) > 0)
                                grilleEtatInter1v1[i, j] = 2;
                            if (CompteurCellulesVivantes1v1(grille) < 0)
                                grilleEtatInter1v1[i, j] = 5;
                        }
                    }

                    if ((grille[i, j] == 0) && (compteurFamille1Rang1 == 3))
                        grilleEtatInter1v1[i, j] = 2;
                    if ((grille[i, j] == 0) && (compteurFamille2Rang1 == 3))
                        grilleEtatInter1v1[i, j] = 5;
                }
            }
            return grilleEtatInter1v1;
        }


        [System.STAThreadAttribute()]
        static void Main(string[] args)
        {
            int h = 1;


            do
            {
                Console.Clear();

                Console.WriteLine("Bienvenue au Jeu de la Vie !\n");

                Console.WriteLine("Saisir une valeur de remplissage : (entre 0,1 ou 1)");

                double remplissage = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Saisir un nombre de lignes : ");

                int ligne = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Saisir un nombre de colonnes : ");

                int colonne = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Voulez-vous activer le bonus de la variante de la règle R4B ? (oui/non)");
                string varianteR4B = Convert.ToString(Console.ReadLine());
                if (varianteR4B == "oui")
                {
                    Console.WriteLine("Bonus règle R4B activé !\n");
                }
                else
                {
                    Console.WriteLine("Bonus règle R4B désactivé !\n");
                }

                Console.WriteLine("Voulez-vous activer le bonus de l'état stable ? (oui/non)");

                string etatStable = Convert.ToString(Console.ReadLine());
                int nbrEtatAStabiliser = 99999999;
                if (etatStable == "oui")
                {
                    Console.WriteLine("Bonus état stable activé !");
                    Console.WriteLine("Pour combien d'états voulez-vous vérifier la stabilité ?");
                    nbrEtatAStabiliser = Convert.ToInt16(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Bonus état stable désactivé !");
                }

                string g = "";
                int compteurGeneration = 1;
                string etatsInter = "";
                Console.Clear();

                Console.WriteLine("Voulez vous afficher les etats intermediaires ? (oui/non)");
                etatsInter = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Choisissez le mode de jeu : ");
                Console.WriteLine("Une seule population > 1 ");
                Console.WriteLine("Deux populations adverses > 2 ");
                int choixMode = Convert.ToInt16(Console.ReadLine());

                if (choixMode == 1)
                {
                    int[,] grille = Grille(ligne, colonne, remplissage);
                    int[,] grilleAfficher = new int[grille.GetLength(0), grille.GetLength(1)];
                    for (int i = 0; i < grille.GetLength(0); i++)
                    {
                        for (int j = 0; j < grille.GetLength(1); j++)
                        {
                            grilleAfficher[i, j] = grille[i, j];

                        }
                    }
                    Fenetre gui = new Fenetre(grilleAfficher, 15, 0, 0, "Jeu de la vie");
                    int compteurStabilisation = 0;
                    do
                    {
                        
                        int nombreCellulesVivantes = CompteurCellulesVivantes(grille);
                        Console.Clear();
                        AfficherGrille(grille);         //Affiche la grille de la nouvelle generation dans la console.
                        Console.WriteLine("Generation n :" + compteurGeneration);       //Donne le numero de generation
                        Console.WriteLine("Il y a " + CompteurCellulesVivantes(grille) + " cellules vivantes");         // Affiche un compteur du nombre de cellules vivantes a la generation donnee.
                        gui.changerMessage("Il y a " + CompteurCellulesVivantes(grille) + " cellules vivantes");

                        if (etatsInter == "oui")
                        {
                            Console.WriteLine("Appuyer sur une touche pour continuer");
                            Console.ReadKey();
                            Console.Clear();
                            //Cree une grille intermediaire.
                            int[,] grilleInter = GrilleEtatInter(grille);
                            AfficherGrille(grilleInter);
                            for (int i = 0; i < grille.GetLength(0); i++)
                            {
                                for (int j = 0; j < grille.GetLength(1); j++)
                                {
                                    grilleAfficher[i, j] = grilleInter[i, j];
                                }
                            }
                            gui.RafraichirTout();

                        }

                        Console.WriteLine("Appuyer sur Entree pour passer a la generation suivante, ou saisissez 'stop' pour arreter");
                        g = Convert.ToString(Console.ReadLine());
                        grille = NewGrille(grille);

                        for (int i = 0; i < grille.GetLength(0); i++)
                        {
                            for (int j = 0; j < grille.GetLength(1); j++)
                            {
                                grilleAfficher[i, j] = grille[i, j];

                            }
                        }
                        gui.RafraichirTout();

                        if (nombreCellulesVivantes == CompteurCellulesVivantes(grille))
                        {
                            compteurStabilisation++;
                        }
                        else
                        {
                            compteurStabilisation = 0;
                        }
                        if (compteurStabilisation == nbrEtatAStabiliser)
                        {
                            g = "stop";
                            Console.WriteLine("La generation est stable depuis " + nbrEtatAStabiliser + " generations. On peut donc arreter le programme.");
                        }
                        compteurGeneration++;
                    } while (g == "");
                }



                if (choixMode == 2)
                {
                    int[,] grille = Grille1v1(ligne, colonne, remplissage);
                    int[,] grilleAfficher = new int[grille.GetLength(0), grille.GetLength(1)];
                    for (int i = 0; i < grille.GetLength(0); i++)
                    {
                        for (int j = 0; j < grille.GetLength(1); j++)
                        {
                            grilleAfficher[i, j] = grille[i, j];

                        }
                    }
                    Fenetre gui = new Fenetre(grilleAfficher, 15, 0, 0, "Jeu de la vie");
                    int compteurStabilisation = 0;


                    do
                    {
                        
                        int nombreCellulesVivantes = CompteurCellulesVivantes(grille);
                        Console.Clear();
                        AfficherGrille(grille);         //affiche la grille de la nouvelle generation dans la console.
                        Console.WriteLine("Génération n :" + compteurGeneration);       //donne le numero de generation
                        Console.WriteLine("Il y a " + CompteurCellulesVivantes(grille) + " cellules vivantes");         // affiche un compteur du nombre de cellules vivantes a la génération donnee.
                        gui.changerMessage("Il y a " + CompteurCellulesVivantes(grille) + " cellules vivantes");



                        if (etatsInter == "oui")
                        {
                            Console.WriteLine("Appuyer sur une touche pour continuer");
                            Console.ReadKey();
                            Console.Clear();
                            //crée une grille intermédiaire.
                            int[,] grilleInter = GrilleEtatInter1v1(grille);
                            AfficherGrille(grilleInter);
                            for (int i = 0; i < grille.GetLength(0); i++)
                            {
                                for (int j = 0; j < grille.GetLength(1); j++)
                                {
                                    grilleAfficher[i, j] = grilleInter[i, j];

                                }
                            }
                            gui.RafraichirTout();


                        }

                        Console.WriteLine("Appuyer sur Entrée pour passer a la génération suivante, ou saisissez 'stop' pour arrêter");
                        g = Convert.ToString(Console.ReadLine());
                        grille = NewGrille1v1(grille, varianteR4B);
                        for (int i = 0; i < grille.GetLength(0); i++)
                        {
                            for (int j = 0; j < grille.GetLength(1); j++)
                            {
                                grilleAfficher[i, j] = grille[i, j];
                            }
                        }
                        gui.RafraichirTout();

                        if (nombreCellulesVivantes == CompteurCellulesVivantes(grille))
                        {
                            compteurStabilisation++;
                        }
                        else
                        {
                            compteurStabilisation = 0;
                        }
                        if (compteurStabilisation == nbrEtatAStabiliser)
                        {
                            g = "stop";
                            Console.WriteLine("La grille est stable depuis " + nbrEtatAStabiliser + " générations. On peut donc arrêter le programme.");
                        }
                        compteurGeneration++;

                    } while (g == "");

                }

                Console.WriteLine("Voulez vous recommencer ou fermer le programme\n 1 : Recommencer\n 2: Fermer\n");
                h = Convert.ToInt16(Console.ReadLine());

            } while (h != 2);

        }
    }
}

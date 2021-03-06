﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using projetCS;
namespace TestProjetCS1
{
    /// <summary>
    /// Description résumée pour TestGrille
    /// </summary>
    [TestFixture]
    public class GrilleTest
    {
        public GrilleTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        Grille grille {
            get {
                return new Grille("bonne grille", DateTime.Now,
                    new char[]     {'1','2','3','4','5','6','7','8','9' },
                    new char[][] {
                        new char[] { '6','2','3','7','5','9','1','8','4' },
                        new char[] { '4','5','7','2','8','1','3','6','9' },
                        new char[] { '8','1','9','3','4','6','2','5','7' },
                        new char[] { '2','4','6','8','9','5','7','3','1' },
                        new char[] { '3','9','5','1','7','2','6','4','8' },
                        new char[] { '7','8','1','4','6','3','5','9','2' },
                        new char[] { '1','3','4','5','2','8','9','7','6' },
                        new char[] { '5','6','8','9','1','7','4','2','3' },
                        new char[] { '9','7','2','6','3','4','8','1','5' }            
                    }
                );
            }
        }

        Grille grilleFausse
        {
            get {
                return new Grille("grille fausse", DateTime.Now,
                    new char[]     { '1','2','3','4','5','6','7','8','9' },
                    new char[][] {
                        new char[] { '6','2','3','7','5','9','1','8','4' },
                        new char[] { '4','5','7','2','8','1','3','6','9' },
                        new char[] { '8','1','9','3','4','6','2','5','7' },
                        new char[] { '2','4','6','8','9','5','7','3','1' },
                        new char[] { '3','9','5','1','7','2','6','4','8' },
                        new char[] { '5','8','1','4','6','3','5','9','2' },
                        new char[] { '1','3','4','5','2','8','9','7','6' },
                        new char[] { '5','6','8','9','1','7','4','2','3' },
                        new char[] { '9','7','2','6','3','4','8','1','5' }
                    }
                );
            }
        }
        Grille grilleLigneIregulieres
        {
            get {
                return new Grille("grille ligne irreguliere", DateTime.Now,
                    new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
                    new char[][] {
                        new char[] { '6','2','3','7','5','9','1','8','4' },
                        new char[] { '4','5','7','2','8','1','3','6','9' },
                        new char[] { '8','1','9','3','4','6','2','5','7' },
                        new char[] { '2','4','6','8','9','5','7','3','1' },
                        new char[] { '3','9','5','1','7','2','6','4','8' },
                        new char[] { '7','8','1','4','6','3','5','9' },
                        new char[] { '1','3','4','5','2','8','9','7','6' },
                        new char[] { '5','6','8','9','1','7','4','2','3' },
                        new char[] { '9','7','2','6','3','4','8','1','5' }            
                    }
                );
            }
        }
        Grille grilleNonCarrée {
            get {
                return new Grille("grille non carrée", DateTime.Now,
                    new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
                    new char[][] {
                        new char[] { '6','2','3','7','5','9','1','8','4' },
                        new char[] { '4','5','7','2','8','1','3','6','9' },
                        new char[] { '8','1','9','3','4','6','2','5','7' },
                        new char[] { '2','4','6','8','9','5','7','3','1' },
                        new char[] { '3','9','5','1','7','2','6','4','8' },
                        new char[] { '7','8','1','4','6','3','5','9','2' },
                        new char[] { '1','3','4','5','2','8','9','7','6' },
                        new char[] { '5','6','8','9','1','7','4','2','3' }      
                    }
                );
            }
        }
        Grille grilleVide {
            get {
                return new Grille("grille vide", DateTime.Now,
                    new char[] { },
                    new char[][] {
                    }
                );
            }
        }
        Grille grilleMauvaisCharactères {
            get {
                return new Grille("grille avec mauvais charactère", DateTime.Now,
                    new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
                    new char[][] {
                        new char[] { '6','2','3','7','5','9','1','8','4' },
                        new char[] { '4','5','7','2','8','1','3','6','9' },
                        new char[] { '8','1','9','3','4','6','2','5','7' },
                        new char[] { '2','4','6','8','9','5','7','3','1' },
                        new char[] { '3','9','5','1','7','2','6','4','8' },
                        new char[] { '7','8','1','4','6','3','5','9','2' },
                        new char[] { '1','3','4','5','2','8','9','7','6' },
                        new char[] { '5','6','8','9','1','7','4','2','3' },
                        new char[] { '9','7','2','s','3','4','8','1','5' }            
                    }
                );
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [Test]
        public void should_return_true_when_sudoku_valid() {
            Assert.IsTrue(grille.IsValid, "une grille valide IsValid renvoie juste");
        }
        [Test]
        public void should_return_false_when_sudoku_invalid()
        {
            Assert.IsFalse(grilleFausse.IsValid, "la grille non valide IsValid renvoi faux");
        }
        [Test]
        public void should_throw_InvalidGrilleException_when_all_line_not_same_length() {
            Assert.Throws<InvalidGrilleException>(() => {
                var i = grilleLigneIregulieres;
            });
        }
        [Test]
        public void should_throw_InvalidGrilleException_when_gird_not_square() {
            Assert.Throws<InvalidGrilleException>(() => {
                var i = grilleNonCarrée;
            });
        }
        [Test]
        public void should_throw_InvalidGrilleException_when_empty_grid() {
            Assert.Throws<InvalidGrilleException>(() => {
                var i = grilleVide;
            });
        }
        [Test]
        public void should_throw_InvalidGrilleException_when_undeclared_character() {
            Assert.Throws<InvalidGrilleException>(() => {
                var i = grilleMauvaisCharactères;
            });
        }
    }
}

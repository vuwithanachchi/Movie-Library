using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEFLICKS
{
    class clsProperties
    {
        // Form Login ---------------------------------------------------
        public class Login
        {
            private string uName, uPass;

            // Username property
            public string UsrName
            {
                get => uName;
                set => uName = value;
            }

            // Password property
            public string UsrPass
            {
                get => uPass;
                set => uPass = value;
            }
        }

        // Form Manage Users ---------------------------------------------------
        public class ManageUsr
        {
            private string uName, uPass, disName;

            // Username property
            public string UsrName
            {
                get => uName;
                set => uName = value;
            }

            // Password property
            public string UsrPass
            {
                get => uPass;
                set => uPass = value;
            }

            // Display name property
            public string DisName
            {
                get => disName;
                set => disName = value;
            }
        }

        // Form Manage Genres ---------------------------------------------------
        public class ManageGenres
        {
            private string genID, genName;

            // Genre ID property
            public string GenID
            {
                get => genID;
                set => genID = value;
            }

            // Genre name property
            public string GenName
            {
                get => genName;
                set => genName = value;
            }
        }

        // Form Manage Actors ---------------------------------------------------
        public class ManageActors
        {
            private string actID, actName;

            // Actor ID property
            public string ActID
            {
                get => actID;
                set => actID = value;
            }

            // Actor name property
            public string ActName
            {
                get => actName;
                set => actName = value;
            }
        }

        // Form Manage Movies ---------------------------------------------------
        public class ManageMovies
        {
            private static string movID, movName, movType, movCover, movDirector, movPCompany, movInRelease, movDuration, movCountry, movLanguage, movBudget, movPlot;
            private static int movRating;
            private static string movGenList, movActList;

            // Movie ID property
            public string MovID
            {
                get => movID;
                set => movID = value;
            }

            // Movie name property
            public string MovName
            {
                get => movName;
                set => movName = value;
            }

            // Movie type property
            public string MovType
            {
                get => movType;
                set => movType = value;
            }

            // Movie genre property
            public void SetGenList(string genList)
            {
                movGenList = genList;
            }

            public string GetGenList()
            {
                return movGenList;
            }

            // Movie cover img property
            public string MovCover
            {
                get => movCover;
                set => movCover = value;
            }

            // Movie rating property
            public int MovRating
            {
                get => movRating;
                set => movRating = value;
            }

            // Movie director property
            public string MovDirector
            {
                get => movDirector;
                set => movDirector = value;
            }

            // Movie production company property
            public string MovPCompany
            {
                get => movPCompany;
                set => movPCompany = value;
            }

            // Movie actor property
            public void SetActList(string actList)
            {
                movActList = actList;
            }

            public string GetActList()
            {
                return movActList;
            }

            // Movie release date property
            public string MovInRelease
            {
                get => movInRelease;
                set => movInRelease = value;
            }

            // Movie duration property
            public string MovDuration
            {
                get => movDuration;
                set => movDuration = value;
            }

            // Movie country property
            public string MovCountry
            {
                get => movCountry;
                set => movCountry = value;
            }

            // Movie language property
            public string MovLanguage
            {
                get => movLanguage;
                set => movLanguage = value;
            }

            // Movie budget property
            public string MovBudget
            {
                get => movBudget;
                set => movBudget = value;
            }

            // Movie plot property
            public string MovPlot
            {
                get => movPlot;
                set => movPlot = value;
            }
        }
    }
}
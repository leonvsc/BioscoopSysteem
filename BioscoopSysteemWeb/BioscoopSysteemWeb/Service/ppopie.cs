namespace BioscoopSysteemWeb.Service
{
    public class LanguageServiceProivder
    {
        Func<string, string> filmDet = lang =>
        {
            if (lang == "eng")
            {
                return "Movie Details";
            }
            return "Film Details";
        };

        Func<string,string> filmInfo = lang =>
        {
            if (lang == "eng")
            {
                return "Information about the movie";
            }
            return "Informatie over de film";
        };

        Func<string, string> nuTeZien = lang =>
        {
            if (lang == "eng")
            {
                return "Now watchable";
            }
            return "Nu te zien";
        };

        Func<string, string> time = lang =>
        {
            if (lang == "eng")
            {
                return "Runtime: ";
            }
            return "Duur van de film: ";
        };

        Func<string, string> datumEnTijd = lang =>
        {
            if (lang == "eng")
            {
                return "Time and Date: ";
            }
            return "Datum en Tijd: ";
        };

        Func<string, string> drieDee = lang =>
        {
            if (lang == "eng")
            {
                return "Movie in 3D: ";
            }
            return "Film in 3D: ";
        };

        Func<string, string> leeftijdInd = lang =>
        {
            if (lang == "eng")
            {
                return "Age Indicator: ";
            }
            return "Leeftijdsindicatie: ";
        };

        Func<string, string> kaartBest = lang =>
        {
            if (lang == "eng")
            {
                return "Order";
            }
            return "Kaartjes bestellen";
        };


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// XMLhandleria käytetään nimensämukaisesti käsittelemään xml tiedoston ja ohjelman välinen toiminta, sisältää mm. XML tiedostoon lisäämisen ja sieltä datan lukemisen
/// </summary>
public class XMLhandler
{
    private XmlDocument xmldoc;
    private string path;

    //Initialisoidaan, luodaan XmlDocument tyyppinen muuttuja ja ladataan siihen tiedosto annetusta polusta
	public XMLhandler(string path)
	{
        this.path = path;
        xmldoc = new XmlDocument();
        xmldoc.Load(path);
	}

    //Palauttaa kysymyksen, current on sessiomuuttuja käyttöliittymäpuolelta joka määrittää mikä kysymys tulee ladata
    public string getQuestion(int current)
    {

        return xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/text").InnerText;
    }

    //Palauttaa kysymykselle annetun aikarajan, current on sessiomuuttuja käyttöliittymäpuolelta joka määrittää minkä kysymyksen aikaraja tulee palauttaa.
    public DateTime getTime(int current)
    {
        return Convert.ToDateTime(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/aika").InnerText);
    }

    //Lisätään annetulle vaihdtoehdolle +1 arvoon "vastattu", joka määrittää kuinka monta on kyseiseen kysymykseen vastannut
    public void addAnswered(int current, int value)
    {
        XmlNode node = xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/vaihtoehto[" + value + "]/vastattu");
        node.InnerText = (Convert.ToInt32(node.InnerText) + 1).ToString();

        node = xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/vastauksia");
        node.InnerText = (Convert.ToInt32(node.InnerText) + 1).ToString();
        xmldoc.Save(path);

    }

    //Palauttaa kysymykselle annettujen vastausvaihtoehtojen määrän, current on sessiomuuttuja käyttöliittymäpuolelta joka määrittää minkä kysymyksen vastausmäärä tulee palauttaa.
    public int getAmount(int current)
    {
        return Convert.ToInt32(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/maara").InnerText);
    }

    //Palauttaa kysymykseen vastattujen kertojen määrän, current on sessiomuuttuja käyttöliittymäpuolelta joka määrittää kysymyksen.
    public int getNumberOfAnswers(int current)
    {
        return Convert.ToInt32(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/vastauksia").InnerText);
    }

    //Palauttaa listan jossa on arvo jokaiseen vastausvaihtoehtoon tietyssä kysymyksessä annettujen vastausten lukumäärä Double koska käytetään luomaan diagrammi
    public List<double> getAnswered(int current)
    {
        List<double> vastaukset = new List<double>();
        int maara = Convert.ToInt32(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/maara").InnerText);

        for (int i = 1; i < maara + 1; i++)
        {


            vastaukset.Add(Convert.ToDouble(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/vaihtoehto[" + i + "]/vastattu").InnerText));


        }

        return vastaukset;

    }

    //tarkistaa onko yhtään kysymystä olemassa
    public bool checkXML()
    {
        

        if (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count != 0)
        {
            return true;
            
        }

        else
        {
            return false;
        }

    }


    //palauttaa listan sen hetkiselle kysymykselle olevista vastausvaihtoehdoista
    public List<string> getOptions(int current)
    {
        

            List<string> kysymykset = new List<string>();

            
            int maara = Convert.ToInt32(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/maara").InnerText);

           

            for (int i = 1; i < maara + 1; i++)
            {


                kysymykset.Add(xmldoc.SelectSingleNode("/kysymykset/kysymys[" + (xmldoc.SelectSingleNode("/kysymykset").ChildNodes.Count - current + 1).ToString() + "]/vaihtoehto[" + i + "]/vaiht").InnerText);


            }


        


            return kysymykset;
        
        
    }


    //tarkistaa onko tietyssä indeksissä olemassa kysymystä
    public bool checkQuestion(int current)
    {
        if (xmldoc.SelectSingleNode("/kysymykset/kysymys[" + current.ToString() + "]/text") != null)
        {
            return true;
        }

        else
            return false;
    }

}
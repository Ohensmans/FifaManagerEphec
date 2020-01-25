using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaError
{
    public class TechnicalError : Exception
    {
        private int _Number;

        public string _Message { get; set; }

        public TechnicalError(SqlException exsql)
        {
            try
            {
                switch (exsql.Number)
                {

                    case 50001: _Message = "Les années doivent être supérieures ou égales à 1900"; _Number = 50001; break;
                    case 50002: _Message = "Ce championnat existe déjà"; _Number = 50002; break;
                    case 50003: _Message = "Ce championnat n’existe pas"; _Number = 50003; break;
                    case 50004: _Message = "La date de début du championnat est trop tardive"; _Number = 50004; break;
                    case 50005: _Message = "il existe déjà une intersaison pour ce championnat"; _Number = 50005; break;
                    case 50006: _Message = "il existe déjà un quarter pour ce championnat"; _Number = 50006; break;
                    case 50007: _Message = "Il ne peut avoir que 2 quarters par championnat"; _Number = 50007; break;
                    case 50008: _Message = "Cette équipe n’existe pas"; _Number = 50008; break;
                    case 50009: _Message = "L'équipe est déjà inscrite à ce championnat"; _Number = 50009; break;
                    case 50010: _Message = "La date de match ne tombe pas pendant un quarter existant"; _Number = 50010; break;
                    case 50011: _Message = "les 2 équipes inscrites sont les mêmes"; _Number = 50011; break;
                    case 50012: _Message = "un match similaire a déjà été prévu pour ce championnat"; _Number = 50012; break;
                    case 50013: _Message = "Une mise à jour plus récente a été effectuée"; _Number = 50013; break;
                    case 50014: _Message = "Un carton rouge a déjà été donné à ce joueur pendant ce match !"; _Number = 50014; break;
                    case 50015: _Message = "Il ne reste plus de suspension à cette carte rouge"; _Number = 50015; break;
                    case 50016: _Message = "Ce carton rouge n’existe pas"; _Number = 50016; break;
                    case 50017: _Message = "Un carton est obtenu entre 0 et 120 minutes de match"; _Number = 50017; break;
                    case 50018: _Message = "Un goal est marqué entre 0 et 120 minutes de match"; _Number = 50018; break;
                    case 50019: _Message = "Ce carton jaune n’existe pas"; _Number = 50019; break;
                    case 50020: _Message = "Ce goal n’existe pas"; _Number = 50020; break;
                    case 50021: _Message = "Une feuille de match existe déjà pour cette équipe et pour ce match !"; _Number = 50021; break;
                    case 50022: _Message = "Il existe déjà 2 feuilles de match pour ce match !"; _Number = 50022; break;
                    case 50023: _Message = "Cette feuille de match n’existe pas"; _Number = 50023; break;
                    case 50024: _Message = "Il y a déjà 7 joueurs inscrits sur cette feuille de match"; _Number = 50024; break;
                    case 50025: _Message = "Ce joueur n’est pas inscrit dans l’équipe"; _Number = 50025; break;
                    case 50026: _Message = "Joueur inscrit avec un carton rouge, ne peut pas être inscrit"; _Number = 50026; break;
                    case 50027: _Message = "Joueur inscrit avec autant ou plus de cartons jaunes que de matchs restants"; _Number = 50027; break;
                    case 50028: _Message = "Joueur déjà inscrit sur la feuille de match"; _Number = 50028; break;
                    case 50029: _Message = "L’équipe doit avoir entre 5 et 10 joueurs"; _Number = 50029; break;
                    case 50030: _Message = "L’équipe compte déjà 10 joueurs"; _Number = 50030; break;
                    case 50031: _Message = "un joueur ne peut pas être transférer lors d'un quarter"; _Number = 50031; break;
                    case 50032: _Message = "un joueur ne peut être transféré que dans une des 3 dernières équipes du classement lors de l’intersaison"; _Number = 50032; break;
                    case 50033: _Message = "Il ne peut avoir qu’une intersaison par championnat"; _Number = 50033; break;
                    case 50034: _Message = "Un nom ne peut être utilisé que par une équipe"; _Number = 50034; break;
                    case 50035: _Message = "Une équipe doit respecter le nombre de joueurs min et max pour s’inscrire dans un championnat"; _Number = 50035; break;
                    case 50036: _Message = "Un joueur doit quitter son équipe avant d''en rejoindre une nouvelle"; _Number = 50036; break;
                    case 50037: _Message = "Une des 2 feuilles d’équipe pour ce match n'a pas été remplie"; _Number = 50037; break;

                    default:
                        _Message = exsql.Message + " -- " + exsql.Number;
                        _Number = exsql.Number;
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public TechnicalError()
        {

        }

        public override string Message
        {
            get { return _Message; }
        }

        public int Number
        {
            get { return _Number; }
        }

    }


}

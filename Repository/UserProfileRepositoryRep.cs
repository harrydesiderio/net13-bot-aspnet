using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Model;


namespace SimpleBot.Repository
{
    public class UserProfileRepositoryRep : IUserProfileRepository
    {

        private Model.ContextDB contextDB;

        public UserProfileRepositoryRep()
        {
            contextDB = new ContextDB();
        }


        /// <summary>
        /// Captura um UserProfile
        /// </summary>
        /// <param name="id">ID do User</param>
        /// <returns>Objeto UserProfile</returns>
        public Model.UserProfile GetProfile(string id)
        {
            //Usando o Lambda para buscar um user profile pelo id
            return contextDB.UserProfile.FirstOrDefault(u => u.Id == id);
        }

        public void SetProfile(Model.UserProfile profile)
        {
            //Buscando um user profile para saber se existe no banco
            var pro = contextDB.UserProfile.FirstOrDefault(u => u.Id == profile.Id);

            //Se existir no banco de dados
            if(pro != null)
            {
                pro.Id = profile.Id;
                pro.Visitas = profile.Visitas;

                contextDB.Entry(pro).State = System.Data.Entity.EntityState.Modified; //Mude o estado do objeto para atualização
            }
            else //Senão incluí um objeto novo e adicione ao banco de dados
            {
                contextDB.Set<Model.UserProfile>().Add(profile); 
            }
            //Faz o commit do banco de dados
            contextDB.SaveChanges();

        }
    }
}
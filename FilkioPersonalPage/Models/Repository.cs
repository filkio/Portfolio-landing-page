using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilkioPersonalPage.Models
{
    public static class Repository
    {
        public static void AddResponse(SubResponce responce)
        {
            List <SubResponceDb> DbList = new List<SubResponceDb>();
            using (MyDbContext cont = new MyDbContext())
            {
                bool check = true;
                DbList = cont.SubResponces.ToList();
                foreach (var item in DbList)
                {
                    if (item.EMail == responce.EMail.ToLower() || item.Phone == responce.Phone.ToLower())
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    //Если почты пользователя или его номера нет в базе данных,
                    SubResponceDb sub = new SubResponceDb { EMail = responce.EMail.ToLower(), Name = responce.Name, Phone = responce.Phone.ToLower() };
                    cont.SubResponces.Add(sub);
                    cont.SaveChanges();
                    responce.Name += ", вы успешно подписались!";

                }
                else
                {
                    responce.Name += ", введённая почта или номер телефона уже заняты!";
                }

            }



        }
    }
}

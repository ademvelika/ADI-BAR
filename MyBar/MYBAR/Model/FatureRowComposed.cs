using MYBAR.Helper;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model
{
    [Serializable]
   public  class FatureRowComposed:FatureRow
    {

        



        public override List<FatureRow> getProdukteDalje()
        {


           
                //recursice logic

                bool Notallsimple = true;
            
                while (Notallsimple)
                {

               Notallsimple = false;
               
                    for (int i = 0; i < Ingredients.Count - 1; i++)
                    {

                        if (Ingredients[i].TypeId == Constants.COMPOSED)
                        {
                            var list = FatureService.getComposedItemsIngredients(Ingredients[i].Productid);
                           
                            foreach (var item in list)
                            {
                            item.Sasi = item.Sasi * Ingredients[i].Sasi;
                                Ingredients.Add(item);
                            }
                        Ingredients.RemoveAt(i);
                        Notallsimple = true;
                        break;
                            //add children
                            //remove object
                        }
                        
                   
                    }


            


                }

            
          

        






            return Ingredients;
        }

        public override FatureRow getInstance()
        {






            return new FatureRowComposed();
        }








    }
}

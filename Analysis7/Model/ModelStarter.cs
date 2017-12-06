using System.Collections.Generic;
using Analysis7.Model.Entities;

namespace Analysis7.Model
{
    public class ModelStarter
    {
        public List<Group> Groups=new List<Group>();

        public List<Event> Events=new List<Event>();

        public ModelStarter()
        {

            var techSources = new List<Source>
            {
                new Source("S1",
                    " функціональні характеристики ПЗ"),
                new Source("S2",
                    " характеристики якості ПЗ"),
                new Source("S3",
                    " характеристики надійності ПЗ")
            };
            var techEvents = new List<Event>()
            {
                new Event("t1",
                    "Затримки у постачанні обладнання, необхідного для підтримки процесу розроблення ПЗ"),
                new Event("t2",
                    "Затримки у постачанні інструментальних засобів, необхідних для підтримки процесу розроблення ПЗ"),
                new Event("t3",
                    "Небажання команди виконавців використовувати інструментальні засоби для підтримки процесу розроблення ПЗ"),
                new Event("t4",
                    "Формування запитів на більш потужні інструментальні засоби розроблення ПЗ"),
                new Event("t5", "Відмова команди виконавців від CASE-засобів розроблення ПЗ"),
                new Event("t6", "Неефективність програмного коду, згенерованого CASE-засобами розроблення ПЗ"),
                new Event("t7",
                    "Неможливість інтеграції CASE-засобів з іншими інструментальними засобами для підтримки процесу розроблення ПЗ"),
                new Event("t8", "Недостатня продуктивність баз(и) даних для підтримки процесу розроблення ПЗ"),
                new Event("t9",
                    "Програмні компоненти, які використовують повторно в ПЗ, мають дефекти та обмежені функціональні можливості")
            };
            Group techGroup = new Group(
                "t",
                "Множина настання технічних ризикових подій",
                techEvents, techSources
                
            );
            var costEvents = new List<Event>
            {
                new Event("c1", "Недооцінювання витрат на реалізацію програмного проекту (надмірно низька вартість)"),
                new Event("c2", "Переоцінювання витрат на реалізацію програмного проекту (надмірно висока вартість)")
            };
            var costGroup=new Group("c", "Множина настання вартісних ризикових подій",costEvents, techSources);
            Events.AddRange(techEvents);
            Groups.Add(techGroup);
            Events.AddRange(costEvents);
            Groups.Add(costGroup);
        }
        //----------------------------------------------
       
    }
};

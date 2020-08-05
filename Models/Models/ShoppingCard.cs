using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class ShoppingCard : BaseEntity<string>
    {
        private CardStatus _cardStatus=CardStatus.Regular;
       
        public CardStatus CardStatus
        {
            get
            {
                return this._cardStatus;
            }
            set
            {
                if (value!=CardStatus.Regular)
                {
                    _cardStatus = value;
                }
               
            }
        }

    }
}

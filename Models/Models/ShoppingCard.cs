using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class ShoppingCard : BaseEntity
    {
        private CardStatus _cardStatus;
       
        public CardStatus CardStatus
        {
            get
            {
                return this.CardStatus;
            }
            set
            {
                if (value!=CardStatus.Regular)
                {
                    _cardStatus = value;
                }
                else
                {
                    _cardStatus = CardStatus.Regular;
                }
            }
        }
    }
}

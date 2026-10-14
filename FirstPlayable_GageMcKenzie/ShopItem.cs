using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GageMcKenzie
{
    internal class ShopItem : Items
    {
        List<int> _posX;
        List<int> _posY;
        Position _itemPos;
        Player _player;
        public bool PickedUp = false;
        char _itemLogo;
        ConsoleColor _itemColor;
        int _price;
        int _effect;
        public ShopItem(Player player, int posX, int posY, int numberOfItems, char itemLogo, ConsoleColor itemColor, int price, int effect) : base(player, posX, posY, numberOfItems, itemLogo, itemColor)
        {
            _itemLogo = itemLogo;
            _itemColor = itemColor;
            _itemPos.x = posX;
            _itemPos.y = posY;

            _player = player;
            _price = price;
            _effect = effect;
        }
        public override void PlaceItem()
        {
            base.PlaceItem();
        }

        public override void OnPickUp()
        {
            if(_player.money >= _price)
            {
                _player.money -= _price;
                if(_effect == 0)
                {
                    _player.maxHealth.health += 10;
                }
                if(_effect == 1)
                {
                    _player.maxShield.health += 10;
                }
                if( _effect == 2)
                {
                    _player.AddDamage(3);
                }
                base.OnPickUp();
                _player.PreviousPos();
            }
            else
            {
                _player.PreviousPos();
            }
        }

    }
}

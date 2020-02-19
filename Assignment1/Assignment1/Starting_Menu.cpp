#include "Starting_Menu.h"

Menu::Menu(float wid, float hei)
{
    //if (!font.loadFromFile("arial.ttf"))
    //{
    //      //Error
    //}
    
    menu[0].setFont(font);
    menu[0].setString("Cannon Ball");
    menu[0].setFillColor(sf::Color::Red);
    menu[0].setPosition(sf::Vector2f(wid / 2, hei / (ITEMS + 1) * 1));
    menu[0].setStyle(sf::Text::Bold);
    menu[0].setCharacterSize(26);

    menu[1].setFont(font);
    menu[1].setString("Start");
    menu[1].setFillColor(sf::Color::Blue);
    menu[1].setPosition(sf::Vector2f(wid / 2, hei / (ITEMS + 1) * 3));
    menu[1].setCharacterSize(16);

    menu[2].setFont(font);
    menu[2].setString("Setting");
    menu[2].setFillColor(sf::Color::White);
    menu[2].setPosition(sf::Vector2f(wid / 2, hei / (ITEMS + 1) * 4));
    menu[2].setCharacterSize(16);

    menu[3].setFont(font);
    menu[3].setString("Exit");
    menu[3].setFillColor(sf::Color::White);
    menu[3].setPosition(sf::Vector2f(wid / 2, hei / (ITEMS + 1) * 5));
    menu[3].setCharacterSize(16);
    
    selIndex = 0;
}

Menu::~Menu()
{
   delete []menu;
}

void Menu::Display(sf::RenderWindow &window)
{
   for(int i = 0; i < ITEMS; i++)
   {
      window.draw(menu[i]);

   }



}

void Menu::up()
{
   if (selIndex - 1 > 0)
   {
     menu[selIndex].setFillColor(sf::Color::White);
     selIndex--;
     menu [selIndex].setFillColor(sf::Color::Blue);
   }


}

void Menu::down()
{
   if(selIndex + 1 < ITEMS - 1)
   {
     menu[selIndex].setFillColor(sf::Color::White);
     selIndex++;
     menu [selIndex].setFillColor(sf::Color::Blue);
   }


}

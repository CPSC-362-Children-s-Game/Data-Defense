#pragma once
#ifndef MAINMENU_H
#define MAINMENU_H

#include <SFML/Graphics.hpp>

#define ITEMS 4
class Menu

{

public:
      Menu(float wid, float hei);
      ~Menu();

      void Display(sf::RenderWindow &window);
      void up();
      void down();

      int Press() {return selIndex;}
      



private:
      int selIndex;
      sf::Font font;
      sf::Text menu[ITEMS];

};

#endif

#include <iostream>
#include <SFML/Graphics.hpp>

#include "Starting_Menu.h"

int main()
{
    sf::RenderWindow window(sf::VideoMode(800,800), "Cannon Ball");
   
    Menu menu(window.getSize().x, window.getSize().y);

    while (window.isOpen())
    {
       sf::Event event;

       while (window.pollEvent(event))
       {
           switch(event.type)
           {
             case sf::Event::KeyReleased:
              
               switch (event.key.code)
	       {
		case sf::Keyboard::Up:
		    menu.up();
		    break;
	
		case sf::Keyboard::Down:
		    menu.down();
		    break;
	
		case sf::Keyboard::Return:
		    switch (menu.Press())
		      {
		      
		       case 3:
			   window.close();
			   break;
		      }
	
		      break;
		}
	
		break;
	    case sf::Event::Closed:
		window.close();
	
		break;


           }


       }
    
       window.clear();
       menu.Display(window);
       window.display();


    }


}

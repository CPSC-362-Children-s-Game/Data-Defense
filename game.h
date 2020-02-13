#pragma once

#ifndef GAME_h
#define GAME_H

#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <SFML/Window.hpp>
#include <SFML/Audio.hpp>
#include <SFML/Network.hpp>

//Wrapper class for game engine.


class Game {
public:
	//Constructors and Destructor
	Game();
	virtual ~Game();

	//Accessors
	const bool running() const;

	//Public Functions
	void pollEvents();
	void update();
	void render();

private:
	//Variables
	sf::RenderWindow* window;
	sf::VideoMode videoMode;
	sf::Event ev;

	//Private Functions
	void initVariables();
	void initWindow();

};

#endif /*GAME_H*/

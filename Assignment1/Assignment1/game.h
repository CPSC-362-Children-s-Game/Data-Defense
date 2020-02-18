#pragma once

#ifndef GAME_H
#define GAME_H

#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <SFML/Window.hpp>
#include <SFML/Audio.hpp>

#include <vector>
#include <ctime>


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

	void updateEnemies();
	void renderEnemies();
	void spawnEnemies();

private:
	//Variables
	sf::RenderWindow* window;
	sf::VideoMode videoMode;
	sf::Event ev;

	//Game Logic
	int points;

	float enemySpawnTimer;
	float enemySpawnTimerMax;
	int maxEnemies;

	//Game Objects
	std::vector<sf::RectangleShape> enemies;
	sf::RectangleShape enemy;

	//Private Functions
	void initVariables();
	void initWindow();
	void initEnemies();
};

#endif /*GAME_H*/
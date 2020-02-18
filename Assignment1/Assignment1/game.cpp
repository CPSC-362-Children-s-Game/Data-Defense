#include "Game.h"

//Constructors and Destructor
Game::Game() {
	this->initVariables();
	this->initWindow();
	this->initEnemies();
}

Game::~Game() {
	delete this->window;
}

//Accessors
const bool Game::running() const {
	return this->window->isOpen();
}

//Public Functions
void Game::pollEvents() {
	//Event polling
	while (this->window->pollEvent(this->ev)) {
		switch (this->ev.type) {
		case sf::Event::Closed:
			this->window->close();
			break;
		case sf::Event::KeyPressed:
			if (this->ev.key.code == sf::Keyboard::Escape)
				this->window->close();
		}
	}
}

void Game::update() {

	this->pollEvents();
	this->updateEnemies();

}

void Game::render() {
	this->window->clear();

	//Draw game objects
	this->renderEnemies();

	this->window->display();
}


void Game::updateEnemies() {
	if (this->enemies.size() < this->maxEnemies) {
		if (this->enemySpawnTimer >= this->enemySpawnTimerMax) {
			this->spawnEnemies();
			this->enemySpawnTimer = 0.0f;
		}
		else
			this->enemySpawnTimer += 1.0f;
	}

	for (auto& e : this->enemies) {
		e.move(0.0f, 1.5f);
	}
}

void Game::renderEnemies() {
	for (auto& e : this->enemies)
		this->window->draw(e);
}

void Game::spawnEnemies() {
	this->enemy.setPosition(
		static_cast<float>(rand() % static_cast<int>(this->window->getSize().x - this->enemy.getSize().x)),
		0.0f);

	this->enemy.setFillColor(sf::Color::Green);
	this->enemies.push_back(this->enemy);
}

//Private Functions

void Game::initVariables() {
	this->window = nullptr;

	this->points = 0;

	this->enemySpawnTimerMax = 1000.0f;
	this->enemySpawnTimer = this->enemySpawnTimerMax;
	this->maxEnemies = 5;
}

void Game::initWindow() {
	this->videoMode.height = 600;
	this->videoMode.width = 800;

	this->window = new sf::RenderWindow(this->videoMode, "Children's Game", sf::Style::Titlebar | sf::Style::Close);
	this->window->setFramerateLimit(60);
}

void Game::initEnemies() {
	this->enemy.setPosition(10.0f, 10.0f);
	this->enemy.setSize(sf::Vector2f(100.0f, 100.0f));
	this->enemy.setScale(sf::Vector2f(0.5f, 0.5f));
	this->enemy.setFillColor(sf::Color::Cyan);
	this->enemy.setOutlineColor(sf::Color::Green);
	this->enemy.setOutlineThickness(1.0f);
}

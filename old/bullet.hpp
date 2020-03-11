#ifndef BULLET_H
#define BULLET_H

#include <SFML/Graphics.hpp>
#include <iostream>

class Bullet {
private:
	sf::CircleShape shape;
	const float Y_VEL = .25f;

public:
	Bullet(float radius, float x, float y) {
		this->shape = sf::CircleShape(radius);
		this->shape.setFillColor(sf::Color::Black);
		this->shape.setPosition(x, y);
	}

	void update() {
		this->shape.move(0, -Y_VEL);
	}

	void draw(sf::RenderWindow* window) {
		window->draw(this->shape);
	}

	float getYPos() const {
		return this->shape.getPosition().y;
	}
};

#endif
#ifndef PLAYER_H
#define PLAYER_H

#include <iostream>
#include <SFML/Graphics.hpp>
#include "bullet.hpp"

class Player {
private:
	sf::CircleShape shape;
	float radius;
	float xVel;
	bool left;
	bool right;

public:
	Player(float radius) {
		this->shape = sf::CircleShape(radius);
		this->radius = radius;
		this->shape.setFillColor(sf::Color::Blue);
		this->xVel = 0;
		this->left = false;
		this->right = false;
		this->shape.setPosition(390, 700);
	}

	void move(float x, float y) {
		shape.move(x, y);
	}

	void update() {
		const float SPEED = .1f;
		const float GRAVITY = .9985f;

		if (this->left) {
			xVel = -SPEED;
		} 
		else if (this->right) {
			xVel = SPEED;
		}
		else {
			xVel *= GRAVITY;
		}

		if (shape.getPosition().x < 0) {
			shape.setPosition(0, 700);
		}
		else if (shape.getPosition().x > 800 - (2 * radius)) {
			shape.setPosition(800 - (2 * radius), 700);
		}

		this->shape.move(xVel, 0);
	}

	sf::CircleShape getShape() const {
		return this->shape;
	}

	void draw(sf::RenderWindow* window) {
		window->draw(this->shape);
	}

	void setLeft(bool left) {
		this->left = left;
	}

	void setRight(bool right) {
		this->right = right;
	}

	void printCtrl() {
		std::cout << xVel << " " << std::endl;
	}
};

#endif
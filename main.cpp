#include <iostream>
#include <SFML/Graphics.hpp>
#include <vector>
#include "player.hpp"
#include "bullet.hpp"

int main() {
	sf::RenderWindow window(sf::VideoMode(800, 800), "Assignment1");
	bool pause = false;
	Player player(20.f);
	std::vector<std::unique_ptr<Bullet>> bullets;

	while (window.isOpen()) {
		sf::Event event;

		while (window.pollEvent(event)) {
			switch (event.type) {
				case sf::Event::Closed:
					window.close();
					break;

				case sf::Event::LostFocus:
					pause = true;
					break;

				case sf::Event::GainedFocus:
					pause = false;
					break;

				case sf::Event::KeyPressed:
					if (event.key.code == sf::Keyboard::Left) {
						player.setLeft(true);
						break;
					}
					if (event.key.code == sf::Keyboard::Right) {
						player.setRight(true);
						break;
					}
					if (event.key.code == sf::Keyboard::Up) {
						float x = player.getShape().getPosition().x + (player.getShape().getRadius() / 2) + 2.5f;
						float y = player.getShape().getPosition().y + (player.getShape().getRadius() / 2) + 2.5f;
						//bullets.push_back(Bullet(5.f, x, y));
						bullets.push_back(std::make_unique<Bullet>(Bullet(5.f, x, y)));
						break;
					}

				case sf::Event::KeyReleased:
					if (event.key.code == sf::Keyboard::Left) {
						player.setLeft(false);
						break;
					}
					if (event.key.code == sf::Keyboard::Right) {
						player.setRight(false);
						break;
					}
			}
		}

		window.clear(sf::Color(255, 255, 255, 255));

		for (int i = 0; i < bullets.size(); i++) {
			bullets[i]->update();
			bullets[i]->draw(&window);

			if (bullets[i]->getYPos() < 0.0f) {
				bullets.erase(bullets.begin() + i);
				i--;
			}
		}

		player.update();
		player.draw(&window);

		window.display();
	}

	return 0;
}
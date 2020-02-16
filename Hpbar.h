#include"Helper.h"

class sf::RectangleShape;


class PlayGui {
private:
	

	sf::RectangleShape hpBarback;
	sf::RectangleShape hpinner;
  
	void initHpBar();

public:

	void updateHp();	

	void renderHpBar(sf::RenderTarget& target);
	void render(sf::RenderTarget& target);

};

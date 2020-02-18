#include"Helper.h"

class sf::RectangleShape;


class PlayGui {
private:
	

	float hpbarsize;
	
	//HP
	std::string hpBarstring;
	sf::Text hpBartext;
	sf::Font font;
	sf::RectangleShape hpBarback;
	sf::RectangleShape hpinner;
	
	void initFont();//set font
	void initHpBar();


public:
	
	int hp;
	int hpMax = 10;
	int damageMax;

	PlayGui();
	virtual ~PlayGui();

	void loseHp(const int hpMax);

	void updateHp();
	void update(const float& dt);

	void renderHpBar(sf::RenderTarget& target);
	void render(sf::RenderTarget& target);

};

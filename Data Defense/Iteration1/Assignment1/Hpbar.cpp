#include"Hpbar.h"
#include"Helper.h"

PlayGui::PlayGui()
{
	this->initHpBar();
	this->initFont();
}

PlayGui::~PlayGui()
{

}


void PlayGui::initFont()
{
	this->font.loadFromFile("arial.ttf");
}

void PlayGui::initHpBar()
{

	float weidth = 200.f;
	float high = 30.f;
	float x = 20.f;
	float y = 20.f;


	this->hpbarsize = weidth;
	
	this->hpBarback.setSize(sf::Vector2f(weidth,high));
	this->hpBarback.setFillColor(sf::Color(50, 50, 50, 200));
	this->hpBarback.setPosition(x, y);

	this->hpinner.setSize(sf::Vector2f(weidth, high));
	this->hpinner.setFillColor(sf::Color(250, 20, 20, 200));
	this->hpinner.setPosition(this->hpBarback.getPosition());
	
	
	this->hpBartext.setFont(this->font);
	this->hpBartext.setPosition(this->hpinner.getPosition().x + 10.f, this->hpinner.getPosition().y + 5.f);

}


void PlayGui::loseHp(const int hpMax)
{
	this->hp=hpMax-1;

	if (this->hp < 0)
	{
		this->hp = 0;
	}
}


void PlayGui::updateHp()
{
	
	

	double percent = (this->hp / this->hpMax);


	this->hpinner.setSize(sf::Vector2f(
		static_cast<float>(std::floor(this->hpbarsize*percent)), this->hpinner.getSize().y));

	this->hpBarstring = std::to_string(this->hp)+ "/" + std::to_string(this->hpMax);
	this->hpBartext.setString(this->hpBarstring);


	}

void PlayGui::update(const float& dt)
{
	this->updateHp();
}

void PlayGui::renderHpBar(sf::RenderTarget& target)
{
	target.draw(this->hpBarback);
	target.draw(this->hpinner);
	target.draw(this->hpBartext);

}

void PlayGui::render(sf::RenderTarget& target)
{
	
	this->renderHpBar(target);
}


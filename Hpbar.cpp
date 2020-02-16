#include"Hpbar.h"
#include"Helper.h"

PlayGui::PlayGui()
{
	this->initHpBar();
}

PlayGui::~PlayGui()
{

}


void PlayGui::initHpBar()
{

	float weidth = 200.f;
	float high = 30.f;
	float x = 20.f;
	float y = 20.f;
	this->hpBarback.setSize(sf::Vector2f(weidth,high));
	this->hpBarback.setFillColor(sf::Color(50, 50, 50, 200));
	this->hpBarback.setPosition(x, y);

	this->hpinner.setSize(sf::Vector2f(weidth, high));
	this->hpinner.setFillColor(sf::Color(250, 20, 20, 200));
	this->hpinner.setPosition(this->hpBarback.getPosition());

}

void PlayGui::renderHpBar(sf::RenderTarget& target)
{
	target.draw(this->hpBarback);
	target.draw(this->hpinner);
}

void PlayGui::render(sf::RenderTarget& target)
{
	
	this->renderHpBar(target);
}


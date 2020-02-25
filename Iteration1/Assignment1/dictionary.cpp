#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main(void) 
{
	string locate;
	int offset;
	string line;

	ifstream theDict;
	theDict.open("words.txt");
	cout << "Type the name that you want to search" << endl;
	cin >> locate;

	if (theDict.is_open())
	{
		while (!theDict.eof())
		{
			getline(theDict, line);
			if ((offset = line.find(locate, 0)) != string::npos)
			{
			cout << "You entered " << locate << endl;
			cout << locate << " has been found " << endl;
			}
		}
		//theDict.close();
	}
	else
	{
		cout << "Could not find the word" << endl;
	}
	theDict.close();
	system("pause");
	return 0;
}

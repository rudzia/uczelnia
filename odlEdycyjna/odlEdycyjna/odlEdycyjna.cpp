// odlEdycyjna.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

struct node
{
	int value;
	int previousCell;
};

int min(int ij_1, int i_1j_1, int i_1j)
{
	if (ij_1 <= i_1j_1 && ij_1 <= i_1j )
	{
		return ij_1;
	}
	else
	{
		if (i_1j_1 <= ij_1 && i_1j_1 <= i_1j)
			return i_1j_1;
		else
			return i_1j;
	}
}
int max(int ij_1, int i_1j_1, int i_1j, int &selected)
{
	if (i_1j_1 >= ij_1 && i_1j_1 >= i_1j)
	{
		selected = 2;
		return i_1j_1;		
	}
	else
	{
		if(ij_1 >= i_1j_1 && ij_1 >= i_1j)
		{
			selected = 1;
			return ij_1;
		}
		else
		{
			selected = 3;
			return i_1j;
		}
	}
}

void odlegloscEdycyjna(string word1, string word2)
{
	int column, rows;
	int sameLetter;
	rows = word1.length() + 1;
	column = word2.length() + 1;

	node ** arrayDistance = new node *[rows];
	for (int i = 0; i < rows; i++)
	{
		arrayDistance[i] = new node[column];
	}

	for (int n = 0; n < column; n++)
	{
		arrayDistance[0][n].value = n;
	}
	for (int m = 0; m < rows; m++)
	{
		arrayDistance[m][0].value = m;
	}

	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < column; j++)
		{
			if (word1[i - 1] == word2[j - 1])
				sameLetter = 0;
			else
				sameLetter = 1;

			arrayDistance[i][j].value = min((arrayDistance[i][j - 1].value + 1), 
				                            (arrayDistance[i - 1][j - 1].value + sameLetter), 
				                            (arrayDistance[i - 1][j].value + 1));
		}
	}

	cout << "Odleglosc edycyjna wynosi: " << arrayDistance[rows - 1][column - 1].value << endl;

	for (int i(0); i < rows; ++i)
		delete[] arrayDistance[i]; 
	delete[] arrayDistance; 
}

void podobienstwoSekwencji(string word1, string word2)
{
	int column, rows;
	int sameLetter;
	int selectedCell = 0;
	column = word1.length() + 1;
	rows = word2.length() + 1;

	node ** sequenceSimilarity = new node *[rows];
	for (int i = 0; i < rows; i++)
	{
		sequenceSimilarity[i] = new node[column];
	}
	for (int n = 0; n < column; n++)
	{
		sequenceSimilarity[0][n].value = 0;
	}
	for (int m = 0; m < rows; m++)
	{
		sequenceSimilarity[m][0].value = 0;
	}
	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < column; j++)
		{
			if (word2[i - 1] == word1[j - 1])
				sameLetter = 1;
			else
				sameLetter = 0;

			sequenceSimilarity[i][j].value = max((sequenceSimilarity[i][j - 1].value),
				                                 (sequenceSimilarity[i - 1][j - 1].value + sameLetter),
				                                 (sequenceSimilarity[i - 1][j].value),
												  selectedCell);
			sequenceSimilarity[i][j].previousCell = selectedCell;

			selectedCell = 0;
		}
	}

	cout << "Podobienstwo sekwencji wynosi: " << sequenceSimilarity[rows - 1][column - 1].value << endl;
	getchar();

	string newWord1, newWord2;
	int y = rows - 1;
	int x = column - 1;

	for (int i = 1; i < rows + column; i++)
	{
		if (sequenceSimilarity[y][x].previousCell == 2)
		{
			newWord1.insert(0,1,word1[x -1]);
			newWord2.insert(0,1,word2[y - 1]);
			x--;
			y--;
		}
		else
			if (sequenceSimilarity[y][x].previousCell == 3)
			{
				newWord1.insert(0,1, '-');
				newWord2.insert(0,1,word2[y-1]);
				y--;
			}
			else
			{
				newWord1.insert(0,1,word1[x - 1]);
				newWord2.insert(0,1,'-');
				x--;
			}
		if (x - 1 < 0 || y-1 < 0)
		{
			break;
		}
	}
		cout << newWord1 << endl;
		cout << newWord2 << endl;
	
	for (int i =0; i < rows; ++i)
		delete[] sequenceSimilarity[i];
	delete[] sequenceSimilarity;
}


int main()
{
	string word1;
	string word2;
	cout << "Podaj pierwszy wyraz: " << endl;
	cin >> word1;
	cout << "Podaj drugi wyraz: " << endl;
	cin >> word2;
	//zrobic potem wczytywanie z pliku
	odlegloscEdycyjna(word1, word2);
	podobienstwoSekwencji(word1, word2);


    return 0;
}


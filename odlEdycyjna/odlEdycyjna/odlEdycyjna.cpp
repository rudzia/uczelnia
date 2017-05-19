// odlEdycyjna.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <algorithm>
#include <fstream>
using namespace std;

							//  A, C, T, G, -
int similarityMetric[5][5]= { { 2, 0, 0, 0, -1 },     
							  { 0, 2, 0, 0, -1 },
							  { 0, 0, 2, 0, -1 },
							  { 0, 0, 0, 2, -1 },
							  { -1, -1, -1, -1, 0 } };

int distanceMetric[5][5] = {{ 0, 1, 1, 1, 1 },
							{ 1, 0, 1, 1, 1 },
							{ 1, 1, 0, 1, 1 },
							{ 1, 1, 1, 0, 1 },
							{ 1, 1, 1, 1, 0 } };

struct node
{
	int value;
	int previousCell;
};
int d(char letterFroWord1, char letterFromWord2)
{
	char alphabet[5] = { 'A', 'C', 'T', 'G', '-' };
	int i, j;

	switch(letterFroWord1)
	{
		case 'A': i = 0; break;
		case 'C': i = 1; break;
		case 'T': i = 2; break;
		case 'G': i = 3; break;
		case '-': i = 4; break;
	}
	switch (letterFromWord2)
	{
		case 'A': j = 0; break;
		case 'C': j = 1; break;
		case 'T': j = 2; break;
		case 'G': j = 3; break;
		case '-': j = 4; break;
	}

	return distanceMetric[i][j];
}
int s(char letterFroWord1, char letterFromWord2)
{
	char alphabet[5] = { 'A', 'C', 'T', 'G', '-' };
	int i, j;

	switch (letterFroWord1)
	{
		case 'A': i = 0; break;
		case 'C': i = 1; break;
		case 'T': i = 2; break;
		case 'G': i = 3; break;
		case '-': i = 4; break;
	}
	switch (letterFromWord2)
	{
		case 'A': j = 0; break;
		case 'C': j = 1; break;
		case 'T': j = 2; break;
		case 'G': j = 3; break;
		case '-': j = 4; break;
	}

	return similarityMetric[i][j];
}
void wypiszWynikDopasowania(node **ArrayMatching, int rows, int column, string word1, string word2)
{
	string newWord1, newWord2;
	int y = rows - 1;
	int x = column - 1;

	for (int i = 1; i < rows + column; i++)
	{
		if (ArrayMatching[y][x].previousCell == 2)
		{
			newWord1.insert(0, 1, word1[x - 1]);
			newWord2.insert(0, 1, word2[y - 1]);
			x--;
			y--;
		}
		else
			if (ArrayMatching[y][x].previousCell == 3)
			{
				newWord1.insert(0, 1, '-');
				newWord2.insert(0, 1, word2[y - 1]);
				y--;
			}
			else
			{
				newWord1.insert(0, 1, word1[x - 1]);
				newWord2.insert(0, 1, '-');
				x--;
			}
		if (x==0 && y==0 || x < 0 || y < 0)
		{
			break;
		}
	}

	cout << newWord1 << endl;
	cout << newWord2 << endl;	
}

int min(int ij_1, int i_1j_1, int i_1j, int &selectedCell)
{
	if (i_1j_1 < ij_1 && i_1j_1 <= i_1j)
	{
		selectedCell = 2;
		return i_1j_1;
	}
	else
	{
		if (ij_1 <= i_1j_1 && ij_1 <= i_1j)
		{
			selectedCell = 1;
			return ij_1;
		}
		else
		{
			selectedCell = 3;
			return i_1j;
		}
	}
}
int max(int ij_1, int i_1j_1, int i_1j, int &selectedCell) // selected cell: 1 - left, 2 - slant, 3 - up
{
	if (i_1j_1 >= ij_1 && i_1j_1 >= i_1j)
	{
		selectedCell = 2;
		return i_1j_1;		
	}
	else
	{
		if(ij_1 >= i_1j_1 && ij_1 >= i_1j)
		{
			selectedCell = 1;
			return ij_1;
		}
		else
		{
			selectedCell = 3;
			return i_1j;
		}
	}
}

void calculateEditDistance(string word1, string word2)
{
	int column, rows;
	int sum_d = 0;
	int selectedCell = 0;
	column = word1.length() + 1;
	rows = word2.length() + 1;

	node ** distanceArray = new node *[rows];
	for (int i = 0; i < rows; i++)
	{
		distanceArray[i] = new node[column];
	}
	distanceArray[0][0].value = 0;

	for (int n = 1; n < column; n++)
	{
		sum_d += d('-', word1[n - 1]);
		distanceArray[0][n].value = sum_d;
		distanceArray[0][n].previousCell = 1;
	}
	sum_d = 0;
	for (int m = 1; m < rows; m++)
	{
		sum_d += d(word2[m - 1], '-');
		distanceArray[m][0].value = sum_d;
		distanceArray[m][0].previousCell = 3;
	}
	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < column; j++)
		{
			distanceArray[i][j].value = min((distanceArray[i][j - 1].value + d('-',word2[i-1])), 
				                            (distanceArray[i - 1][j - 1].value + d(word1[j-1],word2[i-1])), 
				                            (distanceArray[i - 1][j].value + d(word1[j-1],'-')), selectedCell);

			distanceArray[i][j].previousCell = selectedCell;
			selectedCell = 0;
		}
	}

	cout << "Odleglosc edycyjna wynosi: " << distanceArray[rows - 1][column - 1].value << '\n'<<endl;

	wypiszWynikDopasowania(distanceArray, rows, column, word1, word2);


	for (int i(0); i < rows; ++i)
		delete[] distanceArray[i]; 
	delete[] distanceArray; 
}

void similarityWords(string word1, string word2)
{
	int column, rows, isSameLetter;
	int selectedCell = 0;
	int sum_s = 0;
	column = word1.length() + 1;
	rows = word2.length() + 1;

	node ** sequenceSimilarityArray = new node *[rows];
	for (int i = 0; i < rows; i++)
	{
		sequenceSimilarityArray[i] = new node[column];
	}
	sequenceSimilarityArray[0][0].value = 0;
	
	for (int n = 1; n < column; n++)
	{
		sum_s += s('-', word1[n - 1]);
		sequenceSimilarityArray[0][n].value = sum_s;
		sequenceSimilarityArray[0][n].previousCell = 1;
	}
	sum_s = 0;
	for (int m = 1; m < rows; m++)
	{
		sum_s += s(word2[m - 1], '-');
		sequenceSimilarityArray[m][0].value = sum_s;
		sequenceSimilarityArray[m][0].previousCell = 3;
	}
	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < column; j++)
		{
			sequenceSimilarityArray[i][j].value = max((sequenceSimilarityArray[i][j - 1].value + s('-', word2[i - 1])),
													  (sequenceSimilarityArray[i - 1][j - 1].value + s(word1[j - 1], word2[i - 1])),
													  (sequenceSimilarityArray[i - 1][j].value + s(word1[j - 1], '-')),
													   selectedCell);
												  
			sequenceSimilarityArray[i][j].previousCell = selectedCell;
			selectedCell = 0;
		}
	}

	string word11 = word1;
	string word22 = word2;
	cout << "Podobienstwo sekwencji wynosi: " << sequenceSimilarityArray[rows - 1][column - 1].value << '\n'<< endl;

	wypiszWynikDopasowania(sequenceSimilarityArray, rows, column, word1, word2);

	for (int i =0; i < rows; ++i)
		delete[] sequenceSimilarityArray[i];
	delete[] sequenceSimilarityArray;
}

int main()
{
	string word1;
	string word2;

	fstream txtFile;
	txtFile.open("sequences.txt", ios::in | ios::out);
	if (txtFile.is_open())
	{
		cout << "Wczytane dwie sekwencje:" << endl;
		getline(txtFile, word1);
		cout << word1 << endl;
		getline(txtFile, word2);
		cout << word2 << endl;
		txtFile.close();
	}

	cout << '\n' << endl;
	calculateEditDistance(word1, word2);
	similarityWords(word1, word2);

    return 0;
}


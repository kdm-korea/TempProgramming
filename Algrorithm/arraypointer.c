#include <studio.h>
#include <string.h>
#include <stdlib.h>

//12번 문제입니다.

struct Test {
	char text[20];
	int number;
};

int main(){
	struct Test *test = malloc(sizeof(struct Test));
	
	strcpy(test->text,"just testing");
	test->number = 100;
	
	free(test);	
	
	return 0;
}


// 8번 문제입니다.
int* insert(int array[], int loc, int value){
     memmove(array + loc + 1, array + loc, sizeof(array) - loc + 1);

     ary[loc] = value;

	return array;
}
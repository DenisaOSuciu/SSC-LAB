#include <iostream> 
#include <list> 
#include <cstring> 
#include <crypt.h>  

using namespace std;  

 
string target_salt = "$6$L0ViaUtjh.JuyLir$"; 
string target_pw_hash = "$6$L0ViaUtjh.JuyLir$opJLazAoLoZW2pEouDZ0BLEQ7mEXnni.BYX.gKTp5Re6JA0tL642uCq9Rr6hCcc9NOijMDrWB7teyAV9X.F320";  

char null[] = {'\0'};  
// define the maximum length for the password to be searched 
#define MAX_LEN 3  
list<char*> pwlist;  
// check if the pw and salt are matching the hash 

int check_password(char* pw, char* salt, char* hash) { 
char* res = crypt(pw, salt); 
cout << "password " << pw << "\n"; 
cout << "hashes to " << res << "\n"; 
for (int i = 0; i<strlen(hash); i++)  
if (res[i]!=hash[i])
 return 0; 
 cout << "match !!!" << "\n"; 
 return 1; } 
 
 // builds passwords from the given character set  
 // and verifies if they match the target  
 
 char* exhaustive_search(char* charset, char* salt, char* target) { 
 	char* current_password; 
 	char* new_password; 
 	int i, current_len;  // begin by adding each character as a potential 1 character password 
 	for (i = 0; i<strlen(charset); i++){          
 	new_password = new char[2];  
 	new_password[0] = charset[i];
 	new_password[1] = '\0';  
 	pwlist.push_back(new_password);  }  
 	while(true){     // test if queue is not empty and return null if so 
 	if (pwlist.empty()) 
 	return null;  // get the current current_password from queue 
	current_password = pwlist.front(); 
	current_len = strlen(current_password);  
	if (check_password(current_password, salt, target)) 
	return current_password;   
	
	if(current_len < MAX_LEN){ 
	
	for (i = 0; i < strlen(charset); i++){          
	new_password = new char[current_len + 2];   
	memcpy(new_password, current_password, current_len);   		new_password[current_len] = charset[i];  
	new_password[current_len+1] = '\0';
	pwlist.push_back(new_password);  } } 
	pwlist.pop_front(); } }
	
int main() {  
	char* salt; 
	char* target; 
	char* password; 
	
	char charset[] = {'b', 'c', 'd', '\0'};  
	  
	salt = new char[target_salt.length()+1];  
	copy(target_salt.begin(), target_salt.end(), salt);  
	  
	target = new char[target_pw_hash.length()+1];  
	copy(target_pw_hash.begin(), target_pw_hash.end(), target);  
	password = exhaustive_search(charset, salt, target);  
	if  (strlen(password)!=  0)  
	cout  <<  "Password  successfuly  recovered:  "<<password <<" \n";  		else 
	cout << "Failure to find password, try distinct character set of size \n"; } 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

// Define the structure for a song
typedef struct Song {
    char title[50];
    char artist[50];
    int duration; // Duration in seconds
} Song;

// Define the structure for a circular linked list node
typedef struct Node {
    Song data;
    struct Node* next;
} Node;

// Global variable
Node* tail = NULL;

// Function prototypes
Node* createNode(Song data);
int isEmpty();
void addSong(Song data);
void removeSong(char* title);
void displayPlaylist();
void playNext(Node** current);
void clearPlaylist();
void searchSongByTitle(char* title);
void searchSongsByArtist(char* artist);
void displayTotalDuration();
void shuffleAndPlay();
void addSampleSongs();
void backToMenu();

int main() {
    int choice;
    Node* currentSong = NULL;

    addSampleSongs();

    while (1) {
        printf("\n--- Music Playlist Manager ---\n");
        printf("1. Add a Song\n");
        printf("2. Remove a Song\n");
        printf("3. Display Playlist\n");
        printf("4. Play Next Song\n");
        printf("5. Search Song by Title\n");
        printf("6. Search Songs by Artist\n");
        printf("7. Display Total Playlist Duration\n");
        printf("8. Clear Playlist\n");
        printf("9. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        if (choice == 10) break;

        switch (choice) {
            case 1: {
                Song newSong;
                printf("Enter song title: ");
                scanf(" %[^\n]s", newSong.title);
                printf("Enter artist name: ");
                scanf(" %[^\n]s", newSong.artist);
                printf("Enter song duration (seconds): ");
                scanf("%d", &newSong.duration);
                addSong(newSong);
                printf("Song added to the playlist.\n");
                backToMenu();
                break;
            }
            case 2: {
                char title[50];
                printf("Enter the title of the song to remove: ");
                scanf(" %[^\n]s", title);
                removeSong(title);
                backToMenu();
                break;
            }
            case 3:
                displayPlaylist();
                backToMenu();
                break;
            case 4:
                playNext(&currentSong);
                backToMenu();
                break;
            case 5: {
                char title[50];
                printf("Enter the song title to search: ");
                scanf(" %[^\n]s", title);
                searchSongByTitle(title);
                backToMenu();
                break;
            }
            case 6: {
                char artist[50];
                printf("Enter the artist name to search: ");
                scanf(" %[^\n]s", artist);
                searchSongsByArtist(artist);
                backToMenu();
                break;
            }
            case 7:
                displayTotalDuration();
                backToMenu();
                break;
            case 8:
                clearPlaylist();
                backToMenu();
                break;
            default:
                printf("Invalid choice. Please try again.\n");
                backToMenu();
        }
    }

    printf("Exiting the Music Playlist Manager. Goodbye!\n");
    return 0;
}

// Function definitions

Node* createNode(Song data) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    newNode->data = data;
    newNode->next = NULL;
    return newNode;
}

int isEmpty() {
    return tail == NULL;
}

void addSong(Song data) {
    Node* newNode = createNode(data);
    if (isEmpty()) {
        tail = newNode;
        tail->next = tail;
    } else {
        newNode->next = tail->next;
        tail->next = newNode;
        tail = newNode;
    }
}

void removeSong(char* title) {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    Node* current = tail->next;
    Node* previous = tail;
    do {
        if (strcmp(current->data.title, title) == 0) {
            if (current == tail) {
                if (tail->next == tail) {
                    tail = NULL;
                } else {
                    previous->next = current->next;
                    tail = previous;
                }
            } else {
                previous->next = current->next;
            }
            free(current);
            printf("Song '%s' removed from the playlist.\n", title);
            return;
        }
        previous = current;
        current = current->next;
    } while (current != tail->next);

    printf("Song '%s' not found in the playlist.\n", title);
}

void displayPlaylist() {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    Node* current = tail->next;
    printf("\nPlaylist:\n");
    do {
        printf("Title: %s, Artist: %s, Duration: %d seconds\n",
               current->data.title, current->data.artist, current->data.duration);
        current = current->next;
    } while (current != tail->next);
}

void playNext(Node** current) {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    if (*current == NULL) {
        *current = tail->next;
    } else {
        *current = (*current)->next;
    }

    printf("\nNow playing: %s by %s (%d seconds)\n",
           (*current)->data.title, (*current)->data.artist, (*current)->data.duration);
}

void clearPlaylist() {
    if (isEmpty()) {
        printf("The playlist is already empty.\n");
        return;
    }

    Node* current = tail->next;
    Node* temp;
    do {
        temp = current;
        current = current->next;
        free(temp);
    } while (current != tail->next);

    tail = NULL;
    printf("All songs have been removed from the playlist.\n");
}

void searchSongByTitle(char* title) {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    Node* current = tail->next;
    do {
        if (strcmp(current->data.title, title) == 0) {
            printf("\nSong Found: Title: %s, Artist: %s, Duration: %d seconds\n",
                   current->data.title, current->data.artist, current->data.duration);
            return;
        }
        current = current->next;
    } while (current != tail->next);

    printf("Song '%s' not found in the playlist.\n", title);
}

void searchSongsByArtist(char* artist) {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    Node* current = tail->next;
    int found = 0;
    printf("\nSongs by Artist '%s':\n", artist);
    do {
        if (strcmp(current->data.artist, artist) == 0) {
            printf("Title: %s, Duration: %d seconds\n",
                   current->data.title, current->data.duration);
            found = 1;
        }
        current = current->next;
    } while (current != tail->next);

    if (!found) {
        printf("No songs by '%s' found in the playlist.\n", artist);
    }
}

void displayTotalDuration() {
    if (isEmpty()) {
        printf("The playlist is empty.\n");
        return;
    }

    Node* current = tail->next;
    int totalDuration = 0;
    do {
        totalDuration += current->data.duration;
        current = current->next;
    } while (current != tail->next);

    printf("\nTotal Playlist Duration: %d seconds (%d minutes and %d seconds)\n",
           totalDuration, totalDuration / 60, totalDuration % 60);
}

void addSampleSongs() {
    Song song1 = {"Bohemian Rhapsody", "Queen", 354};
    Song song2 = {"Imagine", "John Lennon", 183};
    Song song3 = {"Hotel California", "Eagles", 390};
    Song song4 = {"Shape of You", "Ed Sheeran", 233};

    addSong(song1);
    addSong(song2);
    addSong(song3);
    addSong(song4);

    printf("\nSample songs added to the playlist:\n");
    displayPlaylist();
}

void backToMenu() {
    printf("\nPress Enter to return to the menu...");
    getchar();
    getchar();
}

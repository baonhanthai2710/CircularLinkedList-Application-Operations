#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Book {
    char title[50];
    char author[50];
    float price;
} Book;

typedef struct Node {
    Book data;
    struct Node* next;
} Node;

Node* tail = NULL;

// Helper function to create a new node
Node* createNode(Book data) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    newNode->data = data;
    newNode->next = NULL;
    return newNode;
}

// Check if the list is empty
int isEmpty() {
    return tail == NULL;
}

// Insert a new node at the beginning
void insertAtBeginning(Book data) {
    Node* newNode = createNode(data);
    if (isEmpty()) {
        tail = newNode;
        tail->next = tail;
    } else {
        newNode->next = tail->next;
        tail->next = newNode;
    }
}

// Insert a new node at the end
void insertAtEnd(Book data) {
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

// Insert a new node after a specific node
void insertAfter(char* targetTitle, Book data) {
    if (isEmpty()) return;

    Node* current = tail->next;
    do {
        if (strcmp(current->data.title, targetTitle) == 0) {
            Node* newNode = createNode(data);
            newNode->next = current->next;
            current->next = newNode;
            if (current == tail) {
                tail = newNode;
            }
            return;
        }
        current = current->next;
    } while (current != tail->next);
}

// Remove the first node
void removeFirst() {
    if (isEmpty()) return;

    Node* temp = tail->next;
    if (tail->next == tail) {
        tail = NULL;
    } else {
        tail->next = temp->next;
    }
    free(temp);
}

// Remove the last node
void removeLast() {
    if (isEmpty()) return;

    Node* current = tail->next;
    if (current == tail) {
        free(tail);
        tail = NULL;
    } else {
        while (current->next != tail) {
            current = current->next;
        }
        current->next = tail->next;
        free(tail);
        tail = current;
    }
}

// Remove a node after a specific node
void removeAfter(char* targetTitle) {
    if (isEmpty()) return;

    Node* current = tail->next;
    do {
        if (strcmp(current->data.title, targetTitle) == 0) {
            Node* temp = current->next;
            if (temp == tail) {
                tail = current;
            }
            current->next = temp->next;
            free(temp);
            return;
        }
        current = current->next;
    } while (current != tail->next);
}

// Search for a node
Node* search(char* targetTitle) {
    if (isEmpty()) return NULL;

    Node* current = tail->next;
    do {
        if (strcmp(current->data.title, targetTitle) == 0) {
            return current;
        }
        current = current->next;
    } while (current != tail->next);

    return NULL;
}

// Search nodes based on criteria
void searchByCriteria(float minPrice) {
    if (isEmpty()) return;

    Node* current = tail->next;
    do {
        if (current->data.price > minPrice) {
            printf("Book: %s by %s, $%.2f\n", current->data.title, current->data.author, current->data.price);
        }
        current = current->next;
    } while (current != tail->next);
}

// Print the list
void printList() {
    if (isEmpty()) {
        printf("The list is empty.\n");
        return;
    }

    Node* current = tail->next;
    do {
        printf("Book: %s by %s, $%.2f\n", current->data.title, current->data.author, current->data.price);
        current = current->next;
    } while (current != tail->next);
}

// Selection Sort
void sortSelection() {
    if (isEmpty() || tail->next == tail) return;

    Node* current = tail->next;
    do {
        Node* min = current;
        Node* temp = current->next;
        while (temp != tail->next) {
            if (temp->data.price < min->data.price) {
                min = temp;
            }
            temp = temp->next;
        }

        if (min != current) {
            Book tempData = current->data;
            current->data = min->data;
            min->data = tempData;
        }
        current = current->next;
    } while (current != tail->next);
}

// Merge two lists
void merge(Node* otherTail) {
    if (isEmpty()) {
        tail = otherTail;
    } else if (otherTail != NULL) {
        Node* first = tail->next;
        Node* otherFirst = otherTail->next;

        tail->next = otherFirst;
        otherTail->next = first;
        tail = otherTail;
    }
}

// Remove all nodes based on criteria
void removeByCriteria(float maxPrice) {
    if (isEmpty()) return;

    Node* current = tail->next;
    Node* prev = tail;
    do {
        if (current->data.price > maxPrice) {
            if (current == tail) {
                tail = prev;
            }
            prev->next = current->next;
            free(current);
            current = prev->next;
        } else {
            prev = current;
            current = current->next;
        }
    } while (current != tail->next);

    if (tail != NULL && tail->data.price > maxPrice) {
        removeLast();
    }
}

// Reverse the list
void reverse() {
    if (isEmpty() || tail->next == tail) return;

    Node* prev = tail;
    Node* current = tail->next;
    Node* next;

    do {
        next = current->next;
        current->next = prev;
        prev = current;
        current = next;
    } while (current != tail->next);

    tail->next = prev;
    tail = current;
}

// Main function
int main() {
    Book b1 = {"Book A", "Author 1", 19.99};
    Book b2 = {"Book B", "Author 2", 9.99};
    Book b3 = {"Book C", "Author 3", 14.99};

    insertAtEnd(b1);
    insertAtEnd(b2);
    insertAtBeginning(b3);

    printf("Original List:\n");
    printList();

    printf("\nList after Selection Sort:\n");
    sortSelection();
    printList();

    printf("\nRemoving books with price > 15:\n");
    removeByCriteria(15);
    printList();

    printf("\nReversing the list:\n");
    reverse();
    printList();

    return 0;
}

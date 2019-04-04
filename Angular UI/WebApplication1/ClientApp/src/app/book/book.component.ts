import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from './IBook';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {
  public books: Book[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Book[]>(baseUrl + 'api/Book/Books').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
}

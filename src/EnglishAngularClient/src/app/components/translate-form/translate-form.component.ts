import { Component, OnInit } from '@angular/core';
import { Language } from 'src/app/domain/models/language';
import { Subscription } from 'rxjs';
import { TranslateService } from 'src/app/services/translate.service';

@Component({
  selector: 'app-translate-form',
  templateUrl: './translate-form.component.html',
  styleUrls: ['./translate-form.component.css']
})
export class TranslateFormComponent implements OnInit {
  selectedValue: string;
  selectedCar: string;
  translationText: string;
  translatedText: string;
  languages: Language[] = [];
  subscriptions: Subscription[] = [];

  constructor(
    private translateService: TranslateService,

  ) {}

  ngOnInit() {
    this.populateGroups();
  }

  populateGroups() {
    this.subscriptions.push(
      this.translateService.getAll().subscribe(response => (this.languages = response))
    );
  }

  onEnter() {
    console.log(this.selectedCar + this.translationText);
  }
}

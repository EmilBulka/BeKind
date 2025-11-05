import { Component, OnInit } from '@angular/core';
import { Company } from '../../model/company.model';
import { CompanyService } from '../../services/userCompaniesSvc/user-companies.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
})
export class CompanyListComponent implements OnInit {

  companies: Company[] = [];
  userId = 8; // Replace with logged-in user id later

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.fetchUserCompanies();
  }

  fetchUserCompanies(): void {
    this.companyService.getUserCompanies(this.userId).subscribe({
      next: (data) => this.companies = data.companies,
      error: (err) => console.error('Error loading companies:', err)
    });
  }
}

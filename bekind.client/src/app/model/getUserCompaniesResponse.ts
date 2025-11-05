import { Company } from "./company.model";

export interface GetUserCompaniesResponse {
  userName: string;
  companies: Company[];
}

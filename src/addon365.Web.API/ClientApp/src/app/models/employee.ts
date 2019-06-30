import { User } from "./user";

import { BusinessContact } from "./business-contact";

export class Employee {
  id: string;
  user: User;
  profile: BusinessContact;
}

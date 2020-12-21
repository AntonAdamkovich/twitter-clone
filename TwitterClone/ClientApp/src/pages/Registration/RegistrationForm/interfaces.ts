export interface IRegistrationFormValues {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  username: string;
  password: string;
  passwordConfirmation: string;
}

export interface IRegistrationProps {
  onSubmit: (values: IRegistrationFormValues) => void;
}

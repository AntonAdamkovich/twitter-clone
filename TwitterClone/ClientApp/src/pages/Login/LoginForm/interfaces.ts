export interface ILoginFormValues {
  username: string;
  password: string;
}

export interface ILoginProps {
  onSubmit: (values: ILoginFormValues) => void;
}

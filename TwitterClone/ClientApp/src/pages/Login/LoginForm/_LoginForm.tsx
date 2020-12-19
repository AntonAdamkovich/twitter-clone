import React from 'react';
import { useForm } from 'react-hook-form';
import styled from 'styled-components';

import { Paper } from '@material-ui/core';
import { TextField, Button } from '@material-ui/core';

import TextInput from '../../../components/TextInput';

export interface ILoginFormValues {
  username: string;
  password: string;
}

export interface ILoginProps {
  onSubmit: (values: ILoginProps) => void;
}

export default function({ onSubmit }: ILoginProps) {
  const { handleSubmit, register } = useForm<ILoginFormValues>({
    mode: 'onBlur',
  });

  return (
    <StyledPaper>
      <StyledForm onSubmit={handleSubmit(onSubmit)}>
        <TextInput
          name="username"
          label="Username"
          placeholder="Enter you username"
          // helperText="something"
          ref={register({
            required: 'Please enter your username',
          })}
        />
        <TextInput
          name="password"
          label="Password"
          placeholder="Enter you password"
          helperText="something"
          ref={register({
            required: 'Please enter your password',
          })}
        />
        <Button>submit</Button>
      </StyledForm>
    </StyledPaper>
  )
}

const StyledForm = styled.form`
  display: flex;
  flex-direction: column;
`;

const StyledPaper = styled(Paper)`
  padding: 25px;
`;

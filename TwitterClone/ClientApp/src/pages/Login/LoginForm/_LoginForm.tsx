import React from 'react';
import { useForm } from 'react-hook-form';
import styled from 'styled-components';

import { Paper, Button } from '@material-ui/core';
import TextInput from '../../../components/TextInput';

import { ILoginProps, ILoginFormValues } from './interfaces';

export default function({ onSubmit }: ILoginProps) {
  const { handleSubmit, register, errors, ...sdata } = useForm<ILoginFormValues>({
    mode: 'onBlur',
  });

  return (
    <StyledPaper>
      <StyledForm onSubmit={handleSubmit(onSubmit)}>
        <TextInput
          name="username"
          label="Username"
          errorMessage={errors.username?.message}
          placeholder="Enter you username"
          ref={register({
            required: 'Please enter your username',
          })}
        />
        <TextInput
          name="password"
          label="Password"
          errorMessage={errors.password?.message}
          placeholder="Enter you password"
          ref={register({
            required: 'Please enter your password',
          })}
        />
        <Button type="submit">submit</Button>
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
  width: 100%;
`;

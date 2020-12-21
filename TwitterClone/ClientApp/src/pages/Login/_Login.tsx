import React from 'react';
import styled from 'styled-components';

import PageContainer from '../../components/PageContainer';
import LoginForm from './LoginForm';
import { PropsFromRedux } from './connector';

export interface IHomeOwnProps {
}

export type IHomeProps = IHomeOwnProps & PropsFromRedux;

export default function Login({ submitLogin }: IHomeProps) {
  return (
    <PageContainer maxWidth="xs">
      <CenteringContainer>
        <LoginForm onSubmit={submitLogin}/>
      </CenteringContainer>
    </PageContainer>
  )
}

const CenteringContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100%;
`;

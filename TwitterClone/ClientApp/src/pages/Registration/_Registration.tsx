import React from 'react';
import styled from 'styled-components';

import PageContainer from '../../components/PageContainer';
import RegistrationForm from './RegistrationForm';
import { PropsFromRedux } from './connector';

export interface IHomeOwnProps {
}

export type IHomeProps = IHomeOwnProps & PropsFromRedux;

export default function Registration({ submitRegistration }: IHomeProps) {
  return (
    <PageContainer maxWidth="xs">
      <CenteringContainer>
        <RegistrationForm onSubmit={submitRegistration}/>
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

import { connect, ConnectedProps } from 'react-redux';

import { submitRegistrationAsync } from '../../actionCreators/pages/registration';

const mapDispatchToProps = {
  submitRegistration: submitRegistrationAsync.request,
};

const connector = connect(undefined, mapDispatchToProps);
export type PropsFromRedux = ConnectedProps<typeof connector>

export default connector;

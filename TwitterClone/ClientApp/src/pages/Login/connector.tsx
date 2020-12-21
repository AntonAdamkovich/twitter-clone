import { connect, ConnectedProps } from 'react-redux';

import { submitLoginAsync } from '../../actionCreators/pages/login';

const mapDispatchToProps = {
  submitLogin: submitLoginAsync.request,
};

const connector = connect(undefined, mapDispatchToProps);
export type PropsFromRedux = ConnectedProps<typeof connector>

export default connector;
